using FightersArchive.Data.Entities;


namespace FightersArchive.Data.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Display();
    }
}
