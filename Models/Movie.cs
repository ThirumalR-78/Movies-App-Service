using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocketCinemaAPIService.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        public decimal Popularity { get; set; }
        public int Budget { get; set; }
        public int Revenue { get; set; }
        public string Title { get; set; }
        public string Cast { get; set; }
        public string Homepage { get; set; }
        public string Director { get; set; }
        public string Short_summary { get; set; }
        public string Genre { get; set; }
        [NotMapped]
        public List<string> Genres { get; set; } = new List<string>();
        public string Production_companies { get; set; }
        public int Release_year { get; set; }
    }
}
