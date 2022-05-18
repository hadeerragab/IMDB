using IMDB.Data.Base;
using IMDB.Models;
using System.Collections.Generic;

namespace IMDB.Data.services
{
    public interface IDirectorServices : IEntityBaseRepository<Director>
    {
        //IEnumerable<Director> GetAll();
        //Director GetDirectorByID(int DirectorID);
        //void AddNewDirector(Director NewDirectorData);
        //Director UpdateDirector(int DirectorID, Director NewData);
        //void DeleteDirector(int DirectorID, Director NewData);
    }
}
