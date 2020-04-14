using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ViewModel;

namespace BLL
{
    public class ExportService : IExportService
    {
        private readonly IInstallatieRepository installatieRepository;
        private readonly ILeveradresRepository leveradresRepository;
        private readonly IRelatieRepository relatieRepository;
        private readonly IBatterijRepository batterijRepository;

        public ExportService(IInstallatieRepository _installatieRepository, ILeveradresRepository _leveradresRepository, IRelatieRepository _relatieRepository,
                             IBatterijRepository _batterijRepository)
        {
            installatieRepository = _installatieRepository;
            leveradresRepository = _leveradresRepository;
            relatieRepository = _relatieRepository;
            batterijRepository = _batterijRepository;
        }

        public PdfPreviewViewModel FindInstallationBatteries(int id)
        {
            var installatie = installatieRepository.FindById(id);
            var relatie = relatieRepository.FindById(installatie.RelatieId);
            var batterijen = batterijRepository.FindByInstallatieId(id);

            var model = new PdfPreviewViewModel
            {
                RapportDatum = DateTime.Today,
                InstallatieId = installatie.Id,
                InstallatieType = installatie.InstallatieType.Naam,
                RelatieCode = relatie.XjoRelatieCode,
                RelatieNaam = relatie.Naam,
                RelatieAdres = relatie.Adres,
                RelatiePostcode = relatie.Gemeente.Postcode,
                RelatieGemeente = relatie.Gemeente.Naam
            };

            if (installatie.LeveradresId != null)
            {
                var leveradres = leveradresRepository.FindById((int)installatie.LeveradresId);
                model.LeveradresCode = leveradres.XjoLeveradresId;
                model.LeveradresNaam = leveradres.Naam;
                model.Leveradres = leveradres.Adres;
                model.LeveradresPostcode = leveradres.Gemeente.Postcode;
                model.LeveradresGemeente = leveradres.Gemeente.Naam;
            }

            foreach (var batterij in batterijen)
            {
                if (batterij.Vervangen == false)
                {
                    var batterijViewModel = new BatterijViewModel
                    {
                        BatterijType = batterij.Artikel.Naam,
                        GeplaatstIn = batterij.GeplaatstIn,
                        Datum = batterij.Datum,
                        UserName = batterij.User.Naam
                    };

                    model.Batterijen.Add(batterijViewModel);
                }
                else
                {
                    if ((batterij.ModDatum - DateTime.Now).TotalDays < 30)
                    {
                        var oudeBatterijViewModel = new OudeBatterijViewModel
                        {
                            BatterijType = batterij.Artikel.Naam,
                            GeplaatstIn = batterij.GeplaatstIn,
                            VervangDatum = batterij.ModDatum,
                            VervangenDoor = batterij.User.Naam
                        };

                        model.OudeBatterijen.Add(oudeBatterijViewModel);
                    }
                }
            }

            return model;
        }

        public List<ExportInstallationViewModel> FindInstallations(int id)
        {
            var model = new List<ExportInstallationViewModel>();

            var installaties = installatieRepository.FindByRelatieId(id);

            foreach (var installatie in installaties)
            {
                var exportInstallationViewModel = new ExportInstallationViewModel
                {
                    InstallatieId = installatie.Id,
                    InstallatieCode = installatie.XjoInstallatieCode,
                    InstallatieType = installatie.InstallatieType.Naam
                };

                if (installatie.LeveradresId != null)
                {
                    var leveradres = leveradresRepository.FindById((int)installatie.LeveradresId);
                    exportInstallationViewModel.Naam = leveradres.Naam;
                    exportInstallationViewModel.Adres = leveradres.Adres;
                    exportInstallationViewModel.Gemeente = leveradres.Gemeente.Naam;
                }
                else
                {
                    var relatie = relatieRepository.FindById(installatie.RelatieId);
                    exportInstallationViewModel.Naam = relatie.Naam;
                    exportInstallationViewModel.Adres = relatie.Adres;
                    exportInstallationViewModel.Gemeente = relatie.Gemeente.Naam;
                }

                model.Add(exportInstallationViewModel);
            }

            return model;
        }

        public string GenerateHtmlString(int id)
        {
            var model = FindInstallationBatteries(id);
            string cssFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "lib", "bootstrap", "css", "bootstrap.css");

            var sb = new StringBuilder();
            sb.AppendFormat(@"
                        <html>
                            <head>
                                <meta charset='UTF-8'>
                                <meta name = 'viewport' content = 'width=device-width, initial-scale=1.0' >
                                <link rel='stylesheet' href='{7}' type='text/css' media='all'/>
                            </head>
                            <body>
                                <div class='container'>
                                    <div class='row'>
                                        <div class='col-3 offset-8'>
                                            <h5 style = 'font-weight: bold' >
                                                {0} <br />
                                                {1} <br />
                                                {2} {3}<br />
                                                Relatiecode: {4}
                                            </h5>
                                        </div>
                                    </div>
                                    <div class='row mt-4'>
                                        <div class='col-11 offset-1'>
                                            <h1>Verslag nazicht batterijen {5}</h1>
                                        </div>
                                    </div>
                                    <div class='row'>
                                        <div class='col-2 offset-1'>
                                            <h5>Datum verslag: {6}</h5>
                                        </div>
                                    </div>
                                    <div class='row'>
                                        <div class='col-10 offset-1'><hr style:'border:1px solid black;' /></div>
                                    </div>", model.RelatieNaam, model.RelatieAdres, model.RelatiePostcode, model.RelatieGemeente, model.RelatieCode, model.InstallatieType, model.RapportDatum.ToShortDateString(), cssFilePath);
            if (model.Leveradres != null)
            {
                sb.AppendFormat(@"  <div class='row'>
                                        <div class='col-7 offset-1'>
                                            <h5>
                                                De controle werd uitgevoerd op volgend leveradres:
                                            </h5>
                                        </div>
                                        <div class='col-3'>
                                            <h5>
                                                {0}<br />
                                                {1}<br />
                                                {2} {3}<br />
                                                Leveradres code: {4}
                                            </h5>
                                        </div>
                                    </div>", model.LeveradresNaam, model.Leveradres, model.LeveradresCode, model.LeveradresGemeente, model.LeveradresCode);
            }
            sb.Append(@"            <div class='row mt-5'>
                                        <div class='col-10 offset-1'>
                                            <h5>
                                                De technieker verklaart alle batterijen te hebben getest.<br />
                                                Indien bepaalde batterijen de afgelopen 30 dagen zijn vervangen, worden deze hieronder opgegeven.
                                            </h5>
                                            <br />
                                            <table class='col-12'>
                                                <tr class='border'>
                                                    <th>Type batterij</th>
                                                        <th>Geplaatst in</th>
                                                        <th>Datum vervangen</th>
                                                        <th>Vervangen door</th>
                                                </tr>");
            foreach (var batterij in model.OudeBatterijen)
            {
                sb.AppendFormat(@"              <tr class='border'>
                                                    <td class='border'>{0}</td>
                                                    <td class='border'>{1}</td>
                                                    <td class='border'>{2}</td>
                                                    <td class='border'>{3}</td>
                                                </tr>", batterij.BatterijType, batterij.GeplaatstIn, batterij.VervangDatum.ToShortDateString(), batterij.VervangenDoor);
            }
            sb.Append(@"                    </table>
                                        </div>
                                    </div>
                                    <div class='row mt-5'>
                                        <div class='col-10 offset-1'>
                                            <h5>
                                                Volgende batterijen zijn getest en goed bevonden:
                                            </h5>
                                            <br />
                                            <table class='col-12'>
                                                <tr class='border'>
                                                    <th>Type batterij</th>
                                                    <th>Geplaatst in</th>
                                                    <th>Datum geplaatst</th>
                                                    <th>Geplaatst door</th>
                                                </tr>");
            foreach (var batterij in model.Batterijen)
            {
                sb.AppendFormat(@"              <tr class='border'>
                                                    <td class='border'>{0}</td>
                                                    <td class='border'>{1}</td>
                                                    <td class='border'>{2}</td>
                                                    <td class='border'>{3}</td>
                                                </tr>", batterij.BatterijType, batterij.GeplaatstIn, batterij.Datum.ToShortDateString(), batterij.UserName);
            }
            sb.Append(@"                    </table>
                                        </div>
                                    </div>
                                </div>");

            return sb.ToString();
        }

        public FileResult GeneratePdf(int id)
        {
            var installatie = installatieRepository.FindById(id);
            var relatie = relatieRepository.FindById(installatie.RelatieId);

            var htmlString = GenerateHtmlString(id);
            var baseUrl = "C:/Users/jojo/source/repos/Battery-Service-Support/Battery Service Support";
            DateTime date = DateTime.Now;

            var strings = new List<string>();
            strings.Add("Verslag");
            strings.Add(relatie.Naam);
            strings.Add(date.ToString());
            strings.Add(".pdf");
            var fileName =  String.Join("-", strings);

            //var url = $"http://localhost:49837/Export/PdfPreview/{id}";

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.WebPageWidth = 1024;
            converter.Options.DisplayHeader = true;
            converter.Options.DisplayFooter = true;
            converter.Header.DisplayOnFirstPage = true;
            converter.Header.DisplayOnOddPages = false;
            converter.Header.DisplayOnEvenPages = false;
            converter.Header.Height = 100;
            converter.Footer.DisplayOnFirstPage = true;
            converter.Footer.DisplayOnOddPages = true;
            converter.Footer.DisplayOnEvenPages = true;
            converter.Footer.Height = 50;

            // add image to header
            PdfImageSection pdfHeaderImageSection = new PdfImageSection(30, 30, 180, "wwwroot/images/logo_jojo.png");
            converter.Header.Add(pdfHeaderImageSection);

            // add image to the footer
            PdfImageSection pdfImageSection = new PdfImageSection( 20, 0, 510, "wwwroot/images/footer_jojo.png");
            converter.Footer.Add(pdfImageSection);

            // add page numbers to footer
            PdfTextSection text = new PdfTextSection(0, 30, "Pagina: {page_number} van {total_pages}  ", new System.Drawing.Font("Verdana", 7));
            text.HorizontalAlign = PdfTextHorizontalAlign.Right;
            converter.Footer.Add(text);

            // create a new pdf document converting an url
            //PdfDocument doc = converter.ConvertUrl(url);
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

            byte[] pdf = doc.Save();

            doc.Close();

            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = fileName;
            return fileResult;
            //return RedirectToAction("Index", "Relatie");
            //var installatieDetailVM = installatieRepository.CreateInstallatieDetailViewModel(id);

            //var sb = new StringBuilder();
            //sb.Append(@"
            //            <html>
            //                <head>
            //                    <link href='~/wwwroot/lib/bootstrap/css/bootstrap.css' rel='stylesheet'/>
            //                    <link href='~/wwwroot/css/site.css' rel='stylesheet'/>
            //                </head>
            //                <body>
            //                    <div class='card'>
            //                        <div class='card-header'><h1>This is the generated PDF report!!!</h1></div>
            //                            <div class='card-body'>
            //                                <table align='center'>
            //                                    <tr>
            //                                        <th>Name</th>
            //                                        <th>LastName</th>
            //                                        <th>Age</th>
            //                                        <th>Gender</th>
            //                                    </tr>");
            //foreach (var batterij in installatieDetailVM.Batterijen)
            //{
            //    sb.AppendFormat(@"              <tr>
            //                                        <td>{0}</td>
            //                                        <td>{1}</td>
            //                                        <td>{2}</td>
            //                                        <td>{3}</td>
            //                                    </tr>", batterij.Artikel.Naam, batterij.GeplaatstIn, batterij.Datum, batterij.User.Naam);
            //}
            //sb.Append(@"                    </table>
            //                            </div>
            //                        </div>
            //                    </div>
            //                </body>
            //            </html>");

            //return sb.ToString();
        }
    }
}
