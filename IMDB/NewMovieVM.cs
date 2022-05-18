using IMDB.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB.Models
{
    public class NewMovieVM 
    {
        public int Id { get; set; }

        [Display(Name = "Movie name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }


        [Display(Name = "Movie poster URL")]
        [Required(ErrorMessage = "Movie poster URL is required")]
        public string ImageURL { get; set; }


        //Relationships
        [Display(Name = "Select actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) is required")]
        public List<int> ActorIds { get; set; }


        [Display(Name = "Select a Director")]
        [Required(ErrorMessage = "Movie Director is required")]
        public int DirectorId { get; set; }

    }
}
