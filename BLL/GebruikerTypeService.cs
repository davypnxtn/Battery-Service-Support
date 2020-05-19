using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class GebruikerTypeService : IGebruikerTypeService
    {
        private readonly IGebruikerTypeRepository repository;

        public GebruikerTypeService(IGebruikerTypeRepository _repository)
        {
            repository = _repository;
        }

        // ----- Opvragen gebruikertype op gebruikerTypeId -----
        public GebruikerType GetById(int id)
        {
            return repository.FindById(id);
        }

        // ----- Opvragen alle gebruikertypes -----
        public List<GebruikerType> GetGebruikerTypes()
        {
            return repository.GetGebruikerTypes();
        }
    }
}
