using IMDB.Data.Base;
using IMDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.Data.services
{
    public class DirectorServices : EntityBaseRepository<Director>, IDirectorServices 
    {

        public DirectorServices(AppDbContext context) : base(context)
        {
        }


    //    private AppDbContext _context;

    //    public DirectorServices(AppDbContext context)
    //    {
    //        _context = context;
    //    }

        
    //    public void AddNewDirector(Director NewDirectorData)
    //    {
    //        _context.Directors.Add(NewDirectorData);
    //        _context.SaveChanges();
    //    }


    //    public void DeleteDirector(int DirectorID, Director NewData)
    //    {
    //        _context.Directors.Remove(NewData);
    //        _context.SaveChanges();
    //    }

    //    //public IEnumerable<Actor> GetAll()
    //    //{
    //    //    var All_Actors = _context.Actors.ToList();
    //    //    return All_Actors;
    //    //}

    //    public Director GetDirectorByID(int DirectorID)
    //    {
    //        var DirectorData = _context.Directors.FirstOrDefault(DirectorRequird => DirectorRequird.ID == DirectorID);

    //        return DirectorData;
    //    }

       

    //    public Director UpdateDirector(int DirectorID, Director NewData)
    //    {
    //        _context.Directors.Update(NewData);
    //        _context.SaveChanges();
    //        return NewData;
    //    }

    //    IEnumerable<Director> IDirectorServices.GetAll()
    //    {
    //        var AllDirector = _context.Directors.ToList();
    //        return AllDirector;
    //    }
    }
}
