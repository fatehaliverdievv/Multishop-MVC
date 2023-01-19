using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Multishop.DAL;
using Multishop.Models;
using Multishop.Utilies;
using Multishop.ViewModels;
using System.Data;

namespace Multishop.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        readonly IWebHostEnvironment _env;
        readonly AppDbContext _context;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Products.Include(p => p.ProductColors).ThenInclude(pc => pc.Color).Include(p => p.ProductSizes).ThenInclude(ps => ps.Size).Include(p => p.Category).Include(p => p.ProductImages).Include(p => p.Discount));
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.Name));
            ViewBag.Discounts = new SelectList(_context.Discounts, nameof(Discount.Id), nameof(Discount.Name), nameof(Discount.DiscountPercent));
            ViewBag.ProductInformations = new SelectList(_context.ProductInformations, nameof(ProductInformation.Id), nameof(ProductInformation.Name));
            ViewBag.Sizes = new SelectList(_context.Sizes, nameof(Size.Id), nameof(Size.Name));
            ViewBag.Colors = new SelectList(_context.Colors, nameof(Color.Id), nameof(Color.Name));
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProductVM productVM)
        {
            var coverimg = productVM.CoverImg;
            var otherimg = productVM.Otherimages ?? new List<IFormFile>();
            string result = coverimg.CheckValidate("image/", 400);
            if (result.Length > 0)
            {
                ModelState.AddModelError("CoverImg", result);
            }
            foreach (var item in otherimg)
            {
                result = item.CheckValidate("image/", 400);
                if (result.Length > 0)
                {
                    ModelState.AddModelError("Otherimages", result);
                }
            }
            if (productVM.ColorIds != null)
            {
                foreach (var colorid in productVM.ColorIds)
                {
                    if (!_context.Colors.Any(c => c.Id == colorid))
                    {
                        ModelState.AddModelError("ColorIds", "Bele bir color yoxdu");
                    }
                }
            }
            if (productVM.SizeIds != null)
            {
                foreach (var sizeid in productVM.SizeIds)
                {
                    if (!_context.Sizes.Any(s => s.Id == sizeid))
                    {
                        ModelState.AddModelError("ColorIds", "Bele bir color yoxdu");
                    }
                }
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.Name));
                ViewBag.Discounts = new SelectList(_context.Discounts, nameof(Discount.Id), nameof(Discount.Name), nameof(Discount.DiscountPercent));
                ViewBag.ProductInformations = new SelectList(_context.ProductInformations, nameof(ProductInformation.Id), nameof(ProductInformation.Name));
                ViewBag.Sizes = new SelectList(_context.Sizes, nameof(Size.Id), nameof(Size.Name));
                ViewBag.Colors = new SelectList(_context.Colors, nameof(Color.Id), nameof(Color.Name));
                return View();
            }
            var colors = _context.Colors.Where(c => productVM.ColorIds.Contains(c.Id));
            var sizes = _context.Sizes.Where(s => productVM.SizeIds.Contains(s.Id));
            Product product = new Product
            {
                Name = productVM.Name,
                SellPrice = productVM.SellPrice,
                CostPrice = productVM.CostPrice,
                DiscountId = productVM.DiscountId,
                CategoryId = productVM.CategoryId,
                ProductInformationId = productVM.ProductInformationId,
                Description = productVM.Description,
            };
            List<ProductImage> images = new List<ProductImage>();
            if (coverimg != null)
            {
                images.Add(new ProductImage { ImgUrl = coverimg.SaveFile(Path.Combine(_env.WebRootPath, "assets", "img")), IsCover = true, Product = product });
            }
            if (otherimg != null)
            {
                foreach (var item in otherimg)
                {
                    images.Add(new ProductImage { ImgUrl = item.SaveFile(Path.Combine(_env.WebRootPath, "assets", "img")), IsCover = false, Product = product });
                }
            }
            foreach (var item in colors)
            {
                _context.ProductColors.Add(new ProductColor { Product = product, ColorId = item.Id });
            }
            foreach (var item in sizes)
            {
                _context.ProductSizes.Add(new ProductSize { Product = product, SizeId = item.Id });
            }
            product.ProductImages = images;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int? id)
        {
            ViewBag.Categories = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.Name));
            ViewBag.Discounts = new SelectList(_context.Discounts, nameof(Discount.Id), nameof(Discount.Name), nameof(Discount.DiscountPercent));
            ViewBag.ProductInformations = new SelectList(_context.ProductInformations, nameof(ProductInformation.Id), nameof(ProductInformation.Name));
            ViewBag.Sizes = new SelectList(_context.Sizes, nameof(Size.Id), nameof(Size.Name));
            ViewBag.Colors = new SelectList(_context.Colors, nameof(Color.Id), nameof(Color.Name));
            if (id == null || id == 0) return BadRequest();
            var product = _context.Products.Include(p => p.ProductColors).Include(p => p.ProductSizes).Include(p => p.ProductImages).FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            UpdateProductVM productVM = new UpdateProductVM();
            productVM.Id = product.Id;
            productVM.Description = product.Description;
            productVM.Name = product.Name;
            productVM.CategoryId = product.CategoryId;
            productVM.DiscountId = product.DiscountId;
            productVM.ProductInformationId = product.ProductInformationId;
            productVM.CostPrice = product.CostPrice;
            productVM.SellPrice = product.SellPrice;
            productVM.SizeIds = product.ProductSizes.Select(x => x.SizeId).ToList();
            productVM.ColorIds = product.ProductColors.Select(x => x.ColorId).ToList();
            productVM.ProductImages = product.ProductImages;
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Update(int? id, UpdateProductVM productVM)
        {
            foreach (var item in (productVM.ColorIds ?? new List<int>()))
            {
                if (!_context.Colors.Any(c => c.Id == item)) ;
            }
            foreach (var item in (productVM.SizeIds ?? new List<int>()))
            {
                if (!_context.Sizes.Any(s => s.Id == item)) ;
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_context.Categories, nameof(Category.Id), nameof(Category.Name));
                ViewBag.Discounts = new SelectList(_context.Discounts, nameof(Discount.Id), nameof(Discount.Name), nameof(Discount.DiscountPercent));
                ViewBag.ProductInformations = new SelectList(_context.ProductInformations, nameof(ProductInformation.Id), nameof(ProductInformation.Name));
                ViewBag.Sizes = new SelectList(_context.Sizes, nameof(Size.Id), nameof(Size.Name));
                ViewBag.Colors = new SelectList(_context.Colors, nameof(Color.Id), nameof(Color.Name));
                return View();
            }
            if (id == null||id==0) return BadRequest();
            var existedprod=_context.Products.Include(p => p.ProductColors).Include(p => p.ProductSizes).Include(p => p.ProductImages).FirstOrDefault(x => x.Id == id);
            foreach (var item in existedprod.ProductColors)
            {
                if (productVM.ColorIds.Contains(item.ColorId))
                {
                    productVM.ColorIds.Remove(item.ColorId);
                }
                else
                {
                    _context.ProductColors.Remove(item);
                }
            }
            foreach (var item in existedprod.ProductSizes)
            {
                if (productVM.SizeIds.Contains(item.SizeId))
                {
                    productVM.SizeIds.Remove(item.SizeId);
                }
                else
                {
                    _context.ProductSizes.Remove(item);
                }
            }
            foreach (var item in (productVM.ColorIds ?? new List<int>()))
            {
                _context.ProductColors.Add(new ProductColor { ColorId = item, Product = existedprod });
            }
            foreach(var item in (productVM.SizeIds ?? new List<int>()))
            {
                _context.ProductSizes.Add(new ProductSize { SizeId=item, Product = existedprod });
            }
            foreach (var item in existedprod.ProductImages)
            {
                if (productVM.ImageIds.Contains(item.Id))
                {
                    _context.ProductImages.Remove(item);
                }
            }
            existedprod.Name=productVM.Name;
            existedprod.Description=productVM.Description;
            existedprod.CostPrice=productVM.CostPrice;
            existedprod.SellPrice=productVM.SellPrice;
            existedprod.CategoryId=productVM.CategoryId;
            existedprod.ProductInformationId=productVM.ProductInformationId;
            existedprod.DiscountId=productVM.DiscountId;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}
