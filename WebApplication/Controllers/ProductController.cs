using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            if (!ProductService.Products.Any())
                ProductService.FillListProduct();

            return View(ProductService.Products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = ProductService.Products.FirstOrDefault(c => c.Id == id);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(product);

                product.Id = ProductService.Products.Count + 1;
                ProductService.Products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Edit(int id)
        {
            var product = ProductService.Products.FirstOrDefault(c => c.Id == id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(product);

                ProductService.Products.Remove(ProductService.Products.FirstOrDefault(x => x.Id == id));
                ProductService.Products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = ProductService.Products.FirstOrDefault(c => c.Id == id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(product);

                ProductService.Products.Remove(ProductService.Products.FirstOrDefault(x => x.Id == id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
