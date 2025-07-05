using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class CreateCategoriesDTO
    {
        [Required(ErrorMessage ="this field is required ..")]
        [MinLength(3,ErrorMessage ="min length is 3 ...")]
        public string Name { get; set; }
        public string Discription { get; set; }

    }
}
