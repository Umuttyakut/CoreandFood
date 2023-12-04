using Microsoft.AspNetCore.Mvc;

namespace CoreandFood.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
