using System.ComponentModel.DataAnnotations;

namespace IMDB.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }


        [Display(Name = "image URL")]
        public string ImageURL { get; set; }


        [Display(Name = "age")]
        public int age { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        //
        //public int Fav_DirectorID { get; set; }
        //public int Fav_ActorID { get; set; }
        //public int Fav_MovieID { get; set; }
    }
}
