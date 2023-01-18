using Multishop.Models.Base;
namespace Multishop.Models
{
    public class Color:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductColor>? ProductColors { get; set;}
    }
}
