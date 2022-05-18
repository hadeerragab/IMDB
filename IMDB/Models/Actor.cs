using IMDB.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class Actor :IEntityBase
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

        //this line because actor can partitibate in many movies
        public List<Actor_make_Movie> Actors_Movies { get; set; }
        //public List<FavActor> fav_actor { get; set; }
    }
}
