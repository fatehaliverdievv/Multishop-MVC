using Multishop.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Multishop.ViewModels
{
    public class CreateProductVM
    {
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [Range(0.0, 10000)]
        public double CostPrice { get; set; }
        [Range(0.0, 10000)]
        public double SellPrice { get; set; }
        public int DiscountId { get; set; }
        public int CategoryId { get; set; }
        public int ProductInformationId { get; set; }
        public List<int> ColorIds { get; set; }
        public List<int> SizeIds { get; set; }
        public IFormFile CoverImg { get; set; }
        public List<IFormFile>? Otherimages { get; set;}
    }
}
