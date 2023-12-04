using CoreandFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreandFood.ViewComponents
{
    public class FoodGetList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepository repository = new FoodRepository();
            var frepo = repository.TList();
            return View(frepo);
        }
    }
}
