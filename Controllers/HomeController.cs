using Microsoft.AspNetCore.Mvc;
using Serilog.Formatting.Compact;
using Serilog.Models;
using Serilog.Services;
using System.Diagnostics;

namespace Serilog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMathService _mathService;
        public HomeController(ILogger<HomeController> logger, IMathService mathService)
        {
            _logger = logger;
            _mathService = mathService;
        }

        public IActionResult Index()
        {

            Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Debug(new RenderedCompactJsonFormatter())
    .WriteTo.File("logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

            ////Json FOrmat
            Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Debug(new RenderedCompactJsonFormatter())
    .CreateLogger();


            try
            {
                decimal result = _mathService.Divide(5, 0);
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogWarning(ex, "An exception occured while dividing two numbers");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
