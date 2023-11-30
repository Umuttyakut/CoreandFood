using CoreandFood.Data;
using CoreandFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreandFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(Prolist());
        }
        public List<Class1> Prolist()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150,
            });
            cs.Add(new Class1()
            {
                proname = "Lcd",
                stock = 75,
            });
            cs.Add(new Class1()
            {
                proname = "Usb Disk",
                stock = 50,
            });
            return cs;
                
        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using (var c=new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stock
                }).ToList();
                return cs2;
            }
        }
    }
}
