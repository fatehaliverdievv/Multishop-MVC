using Multishop.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Multishop.Models
{
    public class Product : BaseEntity
    {
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [Range(0.0, 10000)]
        public double CostPrice { get; set; }
        [Range(0.0, 10000)]
        public double SellPrice { get; set; }
        public int ProductInformationId { get; set; }
        public int DiscountId { get; set; }
        public int CategoryId { get; set; }
        public Discount? Discount { get; set; }
        public ProductInformation? ProductInformation { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public Category? Category { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set;}
    }
}
