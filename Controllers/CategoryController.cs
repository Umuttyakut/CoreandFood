using CoreandFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreandFood.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreandFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index()
        {
            
            return View(categoryRepository.TList());
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if (!ModelState.IsValid) //eğer errormessage'dan geçemezsek
                                     //(yani boş bıraktığımızda eylem gerçekleşmeyecek)
            {
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);
            return View(x);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p) 
        {
            var x = categoryRepository.TGet(p.CategoryID);
            x.CategoryName = p.CategoryName;
            x.CategoryDescription = p.CategoryDescription;
            x.Status = true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
