using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projects.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CompanyLocation { get; set; }
        public string Owner { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
