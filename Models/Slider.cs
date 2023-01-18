using Multishop.Models.Base;

namespace Multishop.Models
{
    public class Slider:BaseEntity
    {
        public string PrimaryTitle { get; set; }
        public string SecondaryTitle { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int Order { get; set; }
    }
}
