using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Area.Dtos
{
    public class MovieDTO
    {

        public string Director { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Revenue { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
