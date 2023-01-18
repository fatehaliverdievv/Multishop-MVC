using Multishop.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Multishop.Models
{
    public class Discount:BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
        [Range(0.0,100)]
        public double DiscountPercent{ get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
