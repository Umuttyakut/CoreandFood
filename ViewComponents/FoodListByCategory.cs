﻿using CoreandFood.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreandFood.ViewComponents
{
    public class FoodListByCategory:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            id = 1;
            FoodRepository repository = new FoodRepository();
            var frepo = repository.List(x=>x.CategoryID==id);
            return View(frepo);
        }
    }
}
