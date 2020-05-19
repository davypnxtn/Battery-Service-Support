using Model;

namespace DAL.Interfaces
{
    public interface IGemeenteRepository
    {
        Gemeente FindById(int id);
    }
}
