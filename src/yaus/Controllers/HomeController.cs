using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yaus.Storage;

namespace yaus.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrlStore _urlStore;

        public HomeController(IUrlStore urlStore)
        {
            _urlStore = urlStore;
        }

        public IActionResult Index()
        {
            this.ViewData["CreateUrl"] = this.Url.Link("apiUrl", null);
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> WithToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return this.RedirectToAction(nameof(Index));

            var fullUrl = await _urlStore.Fetch(token);

            if (string.IsNullOrWhiteSpace(fullUrl))
                return this.RedirectToAction(nameof(LinkNotFound));

            return this.Redirect(fullUrl);

        }

        public IActionResult LinkNotFound()
        {
            return View("404");
        }
    }
}
