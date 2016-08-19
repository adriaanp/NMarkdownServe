using System.IO;
using Microsoft.AspNetCore.Mvc;
using Markdig;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace NMarkdownServe.Controllers.ViewComponents
{
    public class MarkdownViewComponent: ViewComponent
    {
        private MarkdownOptions _options;

        public MarkdownViewComponent(IOptions<MarkdownOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync(string pageName)
        {
            var filePath = Path.Combine(_options.Folder, $"{pageName}.md");
            var content = await Task.Run(() => System.IO.File.ReadAllText(filePath));

            var pipeLine = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseBootstrap()
                .Build();

            return View("Default", Markdown.ToHtml(content, pipeLine));
        }
    }
}
