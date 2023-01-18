using Multishop.Models.Base;

namespace Multishop.Models
{
    public class Size:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }

    }
}
