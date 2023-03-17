using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class Suppliers
    {
        [Key]
        public int Code { get; set; }

        [Required]
        public string Name { get; set; }
        public string Telephone { get; set; }
    }
}
