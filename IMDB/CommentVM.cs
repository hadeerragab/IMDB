using IMDB.Models;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Data.ViewModels
{
    public class CommentVM
    {
        public int Id { set; get; }
        public int UserID { set; get; }

        public int MovieID { set; get; }
        public virtual ApplicationUser User { set; get; }
        public virtual Movie Movie { set; get; }

        [StringLength(2500)]
        [Required]
        public string comment { get; set; }
    }
}
