using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using System;
using System.Collections.Generic;
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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BatterijService(IBatterijRepository _repository, IOpmerkingRepository _opmerkingRepository, UserManager<ApplicationUser> _userManager, IHttpContextAccessor _httpContextAccessor)
        {
            repository = _repository;
            opmerkingRepository = _opmerkingRepository;
            userManager = _userManager;
            httpContextAccessor = _httpContextAccessor;
        }

        //Nieuwe Batterij aanmaken
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

        //Aanmaken BatterijDetailViewModel voor Detail view van BatterijController
        public async Task<BatterijDetailViewModel> CreateBatterijDetailViewModel(int id)
        {
            Batterij batterij = FindById(id);
            BatterijDetailViewModel batterijDetailVM = new BatterijDetailViewModel
            {
                Batterij = batterij,
                Opmerkingen = opmerkingRepository.FindByBatterijId(id),
                User = await userManager.FindByIdAsync(batterij.UserId),
                RelatieId = batterij.Installatie.RelatieId,
                LeveradresId = batterij.Installatie.LeveradresId,
            };
            return batterijDetailVM;
        }

        //Ophalen batterij volgens Batterij Id
        public Batterij FindById(int id)
        {
            return repository.FindById(id);
        }

        //Ophalen Batterij volgens Installatie Id
        public List<Batterij> FindByInstallatieId(int id)
        {
            return repository.FindByInstallatieId(id);
        }

        //Update Batterij gegevens. Altijd uitgevoerd bij submitten form in Detail view van BatterijController
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

        //Vervangen oude batterij
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
