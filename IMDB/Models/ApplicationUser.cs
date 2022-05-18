using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class ApplicationUser : IdentityUser 

    {
        

        [Display(Name = "Full Name")]
        public string FullName { get; set; } 


        [Display(Name = "image")]
        public string profilepicURL { get; set; }

        [Display(Name = "age")]
        public int age { get; set; }





    }
}
