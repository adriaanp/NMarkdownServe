using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Markdig;
using System.IO;

namespace MarkdownBrowser.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private MarkdownOptions _options;

        public HomeController(IOptions<MarkdownOptions> optionAccessor)
        {
            _options = optionAccessor.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("{pageName}")]
        public IActionResult Index(string pageName)
        {
            var filePath = Path.Combine(_options.Folder, $"{pageName}.md");
            var content = System.IO.File.ReadAllText(filePath);

            return Content(Markdown.ToHtml(content), "text/html");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
