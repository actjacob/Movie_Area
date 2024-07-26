using Movie_Area.Model;

namespace Movie_Area.Entities
{
    public class Category : BaseModel
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public int MovieCount { get; set; }

        public List<Movie> Movies { get; set; }


    }
}
