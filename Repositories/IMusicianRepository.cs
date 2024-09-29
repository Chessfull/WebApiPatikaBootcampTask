using WebApiPatikaBootcampTask.Models;

namespace WebApiPatikaBootcampTask.Repositories
{
    public interface IMusicianRepository // ← Repository Interface
    {

        List<Musician> GetAll();
        Musician GetById(int id);
        void Add(Musician musician);
        void Update(Musician musician);
        void Delete(int id);
        List<Musician> Search(string name);
    }
}
