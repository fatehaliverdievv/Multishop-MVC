using Multishop.Models.Base;

namespace Multishop.Models
{
    public class ProductImage:BaseEntity
    {
        public bool IsCover { get; set; }
        public string ImgUrl { get; set; }
        public Product? Product { get; set; }
        public int ProductId { get; set; }
    }
}
