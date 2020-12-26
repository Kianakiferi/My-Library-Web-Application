using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
	public class ErrorController : Controller
	{
		[Route("error/403")]
		public IActionResult Forbidden()
		{
			return View(nameof(Forbidden));
		}

		[Route("error/404")]
		public IActionResult PageNotFound()
		{
			return View(nameof(NotFound));


		}
		[Route("error/500")]
		public IActionResult InternalError()
		{
			return View();
		}

	}
}
