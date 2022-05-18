using IMDB.Data.Base;
using IMDB.Models;
using System.Collections.Generic;

namespace IMDB.Data.services
{
    public interface IActorServices : IEntityBaseRepository<Actor>
    {
        Actor GetActorByID(int ActorID);
    }
}
