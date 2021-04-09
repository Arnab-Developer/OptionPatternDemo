using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OptionPatternDemo.Models;
using System.Diagnostics;

namespace OptionPatternDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptionsMonitor<Settings> _optionsMonitor;
        private readonly IOptions<Settings> _options;
        private readonly IOptionsSnapshot<Settings> _optionsSnapshot;

        public HomeController(
            ILogger<HomeController> logger,
            IOptionsMonitor<Settings> optionsMonitor,
            IOptions<Settings> options,
            IOptionsSnapshot<Settings> optionsSnapshot)
        {
            _logger = logger;
            _optionsMonitor = optionsMonitor;
            _options = options;
            _optionsSnapshot = optionsSnapshot;
        }

        public IActionResult Index()
        {
            for (int i = 0; i < 20; i++)
            {
                string name1 = _optionsMonitor.CurrentValue.Name; // Always return the new value
                string name2 = _options.Value.Name; // Always return the old value until the app is restarted
                string name3 = _optionsSnapshot.Value.Name; // Return the new value if it is a new request
            }
            return RedirectToAction(nameof(Privacy));
        }

        public IActionResult Privacy()
        {
            for (int i = 0; i < 5; i++)
            {
                string name1 = _optionsMonitor.CurrentValue.Name; // Always return the new value
                string name2 = _options.Value.Name; // Always return the old value until the app is restarted
                string name3 = _optionsSnapshot.Value.Name; // Return the new value if it is a new request
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
