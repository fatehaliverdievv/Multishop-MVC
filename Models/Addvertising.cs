using Multishop.Models.Base;

namespace Multishop.Models
{
    public class Addvertising:BaseEntity
    {
        public string PrimaryTitle { get; set; }
        public string SecondaryTitle { get; set; }
        public string ImgUrl { get; set; }
        public string ButtonName { get; set; }
    }
}
