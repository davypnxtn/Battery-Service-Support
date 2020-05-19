using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System.Collections.Generic;

namespace BLL
{
    public class ArtikelService : IArtikelService
    {
        private readonly IArtikelRepository repository;

        public ArtikelService(IArtikelRepository _repository)
        {
            repository = _repository;
        }

        // ----- Opvragen artikels op artikelId -----
        public Artikel FindById(int id)
        {
            return repository.FindById(id);
        }

        // ----- Opvragen artikels op xjoArtikelId -----
        public Artikel FindByXjoArtikelId(int id)
        {
            return repository.FindByXjoArtikelId(id);
        }

        // ----- Opvragen alle Artikels -----
        public List<Artikel> GetArtikels()
        {
            return repository.GetArtikels();
        }
    }
}
