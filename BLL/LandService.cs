using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class LandService : ILandService
    {
        private readonly ILandRepository repository;

        public LandService(ILandRepository _repository)
        {
            repository = _repository;
        }

        public Land FindById(int id)
        {
            return repository.FindById(id);
        }
    }
}
