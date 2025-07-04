namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }

        public int? CategoryId { get; set; }
        public Category category { get; set; }
    }
}
