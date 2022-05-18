using IMDB.Data.Base;
using IMDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.Data.services
{

    public class ActorServices : EntityBaseRepository<Actor>, IActorServices
    {
        private readonly AppDbContext _context;
        public ActorServices(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Actor GetActorByID(int ActorID)
        {
            var ActorDetails = _context.Actors
              .Include(am => am.Actors_Movies).ThenInclude(a => a.Movie)
              .FirstOrDefault(n => n.ID == ActorID);

            return ActorDetails;
        }

        

    }
}
