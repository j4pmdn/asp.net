using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    // [NonController] -> home controller này ko hoạt động với url
    // [NonController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // [NonAction] -> HomeController ko hoạt động với url /contact
        [NonAction]
        public IActionResult Contact()
        {
            return View();
        }


        [HttpGet]
        [Route("/api/users")]
        public IActionResult Users([FromHeader] string apiKey, [FromServices]IUserRepository userRepository)
        {
            _logger.LogInformation("[Users] METHOD: {m}, apiKey = {apiKey}", Request.Method, apiKey);
            
            return Content($"Users: {string.Join(',', userRepository.Users)}" );
        }

        [HttpPost]
        [Route("/api/users")]
        public IActionResult Users([FromHeader] string apiKey, [FromServices] IUserRepository userRepository, [FromForm]string user)
        {
            _logger.LogInformation("[Users] METHOD: {m}, apiKey = {apiKey}", Request.Method, apiKey);
            ValidaApiKey(apiKey);

            userRepository.Add(user);
            return Ok();
        }

        private void ValidaApiKey(string apiKey)
        {
            if (apiKey == null)
            {
                throw new ArgumentNullException(nameof(apiKey));
            }
        }


        //[HttpPost]
        //public IActionResult Users(string user)
        //{
        //    _logger.LogInformation("[Users] METHOD: {m}", Request.Method);

        //    return Content("User add: " + user);
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
