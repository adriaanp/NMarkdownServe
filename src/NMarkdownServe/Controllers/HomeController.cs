using Microsoft.AspNetCore.Mvc;

namespace NMarkdownServe.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", "default");
        }

        [Route("{pageName}")]
        public IActionResult Index(string pageName)
        {
            return View("Index", pageName);
        }

        [Route("error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
