using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class GebruikerTypeService : IGebruikerTypeService
    {
        private readonly IGebruikerTypeRepository repository;

        public GebruikerTypeService(IGebruikerTypeRepository _repository)
        {
            repository = _repository;
        }

        public GebruikerType GetById(int id)
        {
            return repository.FindById(id);
        }

        public List<GebruikerType> GetGebruikerTypes()
        {
            return repository.GetGebruikerTypes();
        }
    }
}
