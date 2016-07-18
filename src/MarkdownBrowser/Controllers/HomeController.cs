using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarkdownBrowser;
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

            return Content(Markdown.ToHtml(content));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
