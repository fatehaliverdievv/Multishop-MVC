using Multishop.Models.Base;

namespace Multishop.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public ICollection<Product>? Products{ get; set; }
    }
}
