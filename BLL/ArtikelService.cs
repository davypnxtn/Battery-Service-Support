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

        public Artikel FindById(int id)
        {
            return repository.FindById(id);
        }

        public Artikel FindByXjoArtikelId(int id)
        {
            return repository.FindByXjoArtikelId(id);
        }

        public List<Artikel> GetArtikels()
        {
            return repository.GetArtikels();
        }
    }
}
