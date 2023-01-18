using Multishop.Models.Base;

namespace Multishop.Models
{
    public class ProductInformation:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
