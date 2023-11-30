using CoreandFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreandFood.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreandFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c=new Context();
        public IActionResult Index()
        {
            
            return View(foodRepository.Tlist("Category"));
        }
        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value=x.CategoryID.ToString()

                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddFood(Food p) 
        {
            foodRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFood(int id)
        {
            foodRepository.TDelete(new Food { FoodID=id});
            return RedirectToAction("Index");
        }
    }
}
