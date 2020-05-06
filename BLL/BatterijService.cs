﻿using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BLL
{
    public class BatterijService : IBatterijService
    {
        private readonly IBatterijRepository repository;
        private readonly IOpmerkingRepository opmerkingRepository;
        private readonly IAccountRepository accountRepository;

        //private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IRelatieRepository relatieRepository;
        private readonly ILeveradresRepository leveradresRepository;
        private readonly IInstallatieRepository installatieRepository;

        public BatterijService(IBatterijRepository _repository, IOpmerkingRepository _opmerkingRepository, IAccountRepository _accountRepository, IHttpContextAccessor _httpContextAccessor,
                                IRelatieRepository _relatieRepository, ILeveradresRepository _leveradresRepository, IInstallatieRepository _installatieRepository)
        {
            repository = _repository;
            opmerkingRepository = _opmerkingRepository;
            accountRepository = _accountRepository;
            //userManager = _userManager;
            httpContextAccessor = _httpContextAccessor;
            relatieRepository = _relatieRepository;
            leveradresRepository = _leveradresRepository;
            installatieRepository = _installatieRepository;
        }

        // ----- Nieuwe Batterij aanmaken -----
        public Batterij Add(Batterij nieuweBatterij, int artikelId, string locatie)
        {
            //Vervangen oude batterij
            VervangBatterij(nieuweBatterij);

            //Nieuwe batterij aanmaken
            var datum = DateTime.Now;
            Batterij batterij = new Batterij()
            {
                ArtikelId = artikelId,
                Datum = datum,
                UserId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                GeplaatstIn = nieuweBatterij.GeplaatstIn,
                Info = nieuweBatterij.Info,
                InstallatieId = nieuweBatterij.InstallatieId,
                Locatie = locatie,
                ModDatum = datum,
                Vervangen = false,
                XjoBasisApp2Id = nieuweBatterij.XjoBasisApp2Id,
                XjoBasisAppId = nieuweBatterij.XjoBasisAppId
            };
            repository.Add(batterij);
            return batterij;
        }

        // ----- Nieuwe lijst maken gefilterd op plaatsingsdatum. Batterijen geplaatst vanaf de zoekdatum worden aan de lijst toegevoegd -----
        public async Task<List<ListBatteriesViewModel>> FindByDate(string date, bool isVervangen)
        {
            var model = new List<ListBatteriesViewModel>();

            var listBatteries = await CreateListBatteriesViewModel(isVervangen);

            if (!string.IsNullOrEmpty(date))
            {
                DateTime searchDate = DateTime.Parse(date);

                if (isVervangen)
                {
                    foreach (var batterij in listBatteries)
                    {
                        if (batterij.VervangDatum >= searchDate)
                        {
                            model.Add(batterij);
                        }
                    }
                }
                else
                {
                    foreach (var batterij in listBatteries)
                    {
                        if (batterij.PlaatsingsDatum >= searchDate)
                        {
                            model.Add(batterij);
                        }
                    }
                }

                return model;
            }
            else
            {
                return listBatteries;
            }
            
        }

        // ----- Nieuwe lijst maken gefilterd op relatienaam -----
        public async Task<List<ListBatteriesViewModel>> FindByName(string name, bool isVervangen)
        {
            var model = new List<ListBatteriesViewModel>();

            var listBatteries = await CreateListBatteriesViewModel(isVervangen);

            if (!string.IsNullOrEmpty(name))
            {
                foreach (var batterij in listBatteries)
                {
                    if (batterij.RelatieNaam.ToUpper().Contains(name.ToUpper()))
                    {
                        model.Add(batterij);
                    }
                }

                return model;
            }
            else
            {
                return listBatteries;
            }

        }

        // ----- Nieuwe lijst maken gefilterd op ouderdom batterij. Indien ouder dan 1035 dagen toevoegen aan lijst -----
        public async Task<List<ListBatteriesViewModel>> CreateBatterieWarningList()
        {
            var model = new List<ListBatteriesViewModel>();

            var listBatteries = await CreateListBatteriesViewModel(false);

            foreach (var batterij in listBatteries)
            {
                if ((DateTime.Now - batterij.PlaatsingsDatum).TotalDays > 1035)
                {
                    model.Add(batterij);
                }
            }

            return model;
        }

        // ----- Aanmaken BatterijDetailViewModel voor Detail view van BatterijController -----
        public async Task<BatterijDetailViewModel> CreateBatterijDetailViewModel(int id)
        {
            Batterij batterij = FindById(id);
            BatterijDetailViewModel batterijDetailVM = new BatterijDetailViewModel
            {
                Batterij = batterij,
                Opmerkingen = opmerkingRepository.FindByBatterijId(id),
                User = await accountRepository.FindById(batterij.UserId),
                RelatieId = batterij.Installatie.RelatieId,
                LeveradresId = batterij.Installatie.LeveradresId,
            };
            return batterijDetailVM;
        }

        // ----- Aanmaken ListBatteriesViewModel voor ListBatteries view van BatterijController -----
        public async Task<List<ListBatteriesViewModel>> CreateListBatteriesViewModel(bool isVervangen)
        {
            var model = new List<ListBatteriesViewModel>();

            var batterijen = GetBatteries(isVervangen);

            foreach (var batterij in batterijen)
            {
                var vervangUsernaam = "";
                if (batterij.Vervangen)
                {
                    ApplicationUser vervangUser = await accountRepository.FindById(batterij.VervangenDoor);
                    vervangUsernaam = vervangUser.Naam;
                }

                var installatie = installatieRepository.FindById(batterij.InstallatieId);
                var relatie = relatieRepository.FindById(installatie.RelatieId);


                ListBatteriesViewModel listBatteriesVM = new ListBatteriesViewModel
                {
                    BatterijType = batterij.Artikel.Naam,
                    GeplaatstIn = batterij.GeplaatstIn,
                    PlaatsingsDatum = batterij.Datum,
                    VervangDatum = batterij.ModDatum,
                    UserName = batterij.User.Naam,
                    VervangenDoor = vervangUsernaam,
                    InstallatieId = installatie.Id,
                    InstallatieType = installatie.InstallatieType.Naam,
                    RelatieNaam = relatie.Naam,
                    RelatieCode = relatie.XjoRelatieCode,
                    RelatieAdres = relatie.Adres,
                    RelatiePostcode = relatie.Gemeente.Postcode,
                    RelatieGemeente = relatie.Gemeente.Naam
                };

                if (batterij.Installatie.LeveradresId != null)
                {
                    var leveradres = leveradresRepository.FindById((int)batterij.Installatie.LeveradresId);
                    listBatteriesVM.LeveradresNaam = leveradres.Naam;
                    listBatteriesVM.Leveradres = leveradres.Adres;
                    listBatteriesVM.LeveradresPostcode = leveradres.Gemeente.Postcode;
                    listBatteriesVM.LeveradresGemeente = leveradres.Gemeente.Naam;
                }

                model.Add(listBatteriesVM);
            }

            return model;
        }

        // ----- Ophalen batterij volgens Batterij Id -----
        public Batterij FindById(int id)
        {
            return repository.FindById(id);
        }

        // ----- Ophalen Batterij volgens Installatie Id -----
        public List<Batterij> FindByInstallatieId(int id)
        {
            return repository.FindByInstallatieId(id);
        }

        // ----- Ophalen alle actieve of niet-actieve batterijen -----
        public List<Batterij> GetBatteries(bool isVervangen)
        {
            return repository.GetBatteries(isVervangen);
        }

        // ----- Update Batterij gegevens. Altijd uitgevoerd bij submitten form in Detail view van BatterijController -----
        public Batterij Update(Batterij batterijChanges)
        {
            Batterij batterij = FindById(batterijChanges.Id);
            if (batterij != null)
            {
                batterij.Locatie = batterijChanges.Locatie;
                batterij.ModDatum = DateTime.Now;
                repository.Update(batterij);
            }
            
            return batterij;
        }

        // ----- Vervangen oude batterij -----
        private void VervangBatterij(Batterij oudeBatterij)
        {
            Batterij batterij = FindById(oudeBatterij.Id);
            if (batterij != null)
            {
                batterij.Vervangen = true;
                batterij.VervangenDoor = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                batterij.ModDatum = DateTime.Now;
                repository.Update(batterij);
            }
            
        }
    }
}
