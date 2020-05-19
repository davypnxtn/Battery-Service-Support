using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;

namespace BLL
{
    public class ModDatumService : IModDatumService
    {
        private readonly IModDatumRepository repository;

        public ModDatumService(IModDatumRepository _repository)
        {
            repository = _repository;
        }

        // ----- Opvragen alle moddatums -----
        public ModDatum GetModDatum()
        {
            return repository.GetModDatum();
        }

        // ----- Vergelijken moddatum van test database met moddatum van CRM database -----
        // Niet gebruikt op dit moment wegens geen koppeling met CRM database. Niet kunnen testen.
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
