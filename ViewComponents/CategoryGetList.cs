using CoreandFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreandFood.ViewComponents
{
    public class CategoryGetList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository crepos = new CategoryRepository();
            var crepolist = crepos.TList();
            return View(crepolist);
        }
    }
}
