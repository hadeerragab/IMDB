using IMDB.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Director : IEntityBase
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "profile pic URL")]
        public string profilepicURL { get; set; }

        [Display(Name = "first name")]
        public string Fname { get; set; }

        [Display(Name = "last name")]
        public string Lname { get; set; }

        [Display(Name = "age")]
        public int age { get; set; }

        //relationships

        //1// because dir have one to many relation with movies
        public List<Movie> movies { get; set; }
        //public List<FavDirector> fav_director { get; set; }
    }
}
