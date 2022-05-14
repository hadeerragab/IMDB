using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "user name")]
        public string user_name { get; set; }

        [Display(Name = "password")]
        public int password { get; set; }

        [Display(Name = "profile pic URL")]
        public string profilepicURL { get; set; }

        [Display(Name = "first name")]
        public string Fname { get; set; }

        [Display(Name = "last name")]
        public string Lname { get; set; }

        [Display(Name = "age")]
        public int age { get; set; }



        //relation
        public List<Comment> Comments { get; set; }
    }
}
