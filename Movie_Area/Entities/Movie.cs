using Movie_Area.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Area.Entities
{
    public class Movie : BaseModel
    {
        public string Director { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Revenue { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
