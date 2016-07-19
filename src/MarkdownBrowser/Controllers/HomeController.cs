using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Markdig;
using System.IO;

namespace MarkdownBrowser.Controllers
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
