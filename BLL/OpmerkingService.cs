using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Model;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace BLL
{
    public class OpmerkingService : IOpmerkingService
    {
        private readonly IOpmerkingRepository repository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OpmerkingService(IOpmerkingRepository _repository, IHttpContextAccessor _httpContextAccessor)
        {
            repository = _repository;
            httpContextAccessor = _httpContextAccessor;
        }

        // ----- Toevoegen nieuwe opmerking -----
        public void Add(string notitie, int batterijId)
        {
            Opmerking opmerking = new Opmerking()
            {
                Notitie = notitie,
                BatterijId = batterijId,
                UserId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier),
                ModDatum = DateTime.Now
            };
            repository.Add(opmerking);
        }

        // ----- Opvragen opmerkingen op batterijId -----
        public List<Opmerking> FindByBatterijId(int? id)
        {
            return repository.FindByBatterijId(id);
        }
    }
}
