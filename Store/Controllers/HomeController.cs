using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Data;
using Store.Models;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            //read data
            var result = _context.Products.ToList();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product) {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            Product _product = new Product()
            {
                Name = product.Name,
                Brend = product.Brend,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,
                CreatedAt = DateTime.Now
            
            };
            _context.Products.Add(_product);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        public ActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            Console.WriteLine($"product's Id is {id}!!!!!!!!!!");
            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            var productEdit = new ProductCreate()
            {
                Name = product.Name,
                Brend = product.Brend,
                Category = product.Category,
                Price = product.Price,
                Description = product.Description,

            };

            ViewBag.Id = product.Id;
            ViewBag.CreatedAt = product.CreatedAt.ToString("hh/mm dd/mm/yyyy");

            return View(productEdit);
        }
        [HttpPost]
        public ActionResult Edit(int id, ProductCreate product)
        {
            var _product = _context.Products.Find(id);
            _product.Name = product.Name;
            _product.Brend = product.Brend;
            _product.Category = product.Category;
            _product.Price = product.Price;
            _product.Description = product.Description;
           
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Delete(int id)
        {
            
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return RedirectToAction("Index", "Home");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }







    }
}
