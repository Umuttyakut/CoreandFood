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
        public IActionResult Statistics()
        {
            Context c = new Context();
            var dg=c.Foods.Count();
            ViewBag.d1 = dg;

            var dg2 = c.Categories.Count();
            ViewBag.d2 = dg2;

            var foid = c.Categories.Where(x => x.CategoryName == "Fruit")
                .Select(y => y.CategoryID).FirstOrDefault();
            //ViewBag.d =foid;
            var dg3 = c.Foods.Where(x=>x.CategoryID==foid).Count();
            ViewBag.d3 = dg3;

            var dg4 = c.Foods.Where(x => x.CategoryID == c.Categories.Where
            (y=>y.CategoryName=="Vegetables").
            Select(z=>z.CategoryID).FirstOrDefault()).Count();
            ViewBag.d4 = dg4;

            var dg5 = c.Foods.Sum(x => x.Stock);
            ViewBag.d5 = dg5;

            var dg6 = c.Foods.Where(x => x.CategoryID == c.Categories.Where
            (y => y.CategoryName == "Legumes").Select(z => z.CategoryID).FirstOrDefault()).Count();
            ViewBag.d6 = dg6;

            var dg7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d7 = dg7;

            var dg8= c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.d8 = dg8;

            var dg9=c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = dg9;

            var dg10=c.Categories.Where(x=>x.CategoryName=="Fruit").Select(z => z.CategoryID).FirstOrDefault();
            var dg10p=c.Foods.Where(x=>x.CategoryID==dg10).Sum(x => x.Stock);
            ViewBag.d10=dg10p;

            var dg11 = c.Categories.Where(x => x.CategoryName == "Vegetables").Select(z => z.CategoryID).FirstOrDefault();
            var dg11p = c.Foods.Where(x => x.CategoryID == dg11).Sum(x => x.Stock);
            ViewBag.d11 = dg11p;

            var dg12 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            ViewBag.d12 = dg12;
            return View();
        }
    }
}
