using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class ModDatumService : IModDatumService
    {
        private readonly IModDatumRepository repository;

        public ModDatumService(IModDatumRepository _repository)
        {
            repository = _repository;
        }

        public ModDatum GetModDatum()
        {
            return repository.GetModDatum();
        }

        public bool CompareModData(DateTime ModDatum, DateTime BatterijModDatum)
        {
            int result = DateTime.Compare(ModDatum, BatterijModDatum);
            if (result < 0)
                //ModDatum is earlier than BatterijModDatum
                return true;
            else
                //ModDatum is the same (0) or later (>0) than BatterijModDatum
                return false;
        }
    }
}
