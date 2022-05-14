using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB.Models
{
    public class Comment
    {
        [Key]
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }


        [Key]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public string comment { get; set; }
    }
}
