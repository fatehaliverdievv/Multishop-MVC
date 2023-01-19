﻿using Multishop.Models;
using System.ComponentModel.DataAnnotations;

namespace Multishop.ViewModels
{
    public class UpdateProductVM
    {
        public int Id { get; set; }
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
        public List<int>? ColorIds { get; set; }
        public List<int>? SizeIds { get; set; }
        public List<int>? ImageIds { get; set; }
        public IFormFile? CoverImg { get; set; }
        public List<IFormFile>? Otherimages { get; set; }
        public ICollection<ProductImage>? ProductImages { get; set;}
    }
}
