using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
	public class ErrorController : Controller
	{
        [Route("error/404")]
        public IActionResult PageNotFound()
        {
            return View(nameof(NotFound));

 
        }
        //if (Response.StatusCode == 404)
        //{
        //    return View("/Views/Error/NotFound.cshtml");
        //}

        [Route("error/403")]
        public IActionResult Forbidden()
        {
            return View(nameof(Forbidden));
        }
    }
}
