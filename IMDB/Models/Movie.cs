using IMDB.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB.Models
{
    public class Movie : IEntityBase
    {
        [Key]

        public int ID { get; set; }
        [Display(Name = "Movie name")]
        public string name { get; set; }
        [Display(Name = "Movie imge")]
        public string imageURL { get; set; }


        //relationships

        //this line because actor can partitibate in many movies
        public List<Actor_make_Movie> Actors_Movies { get; set; }

       

        //director 
        //there is a relation one to many between movie & dir so dir_id is a foreign key in movie model
        [Display(Name = "Director ID")]
       
        public int dirictorID { get; set; }
        [ForeignKey("dirictorID")]
        public Director Director { get; set; }



      
    }
}
