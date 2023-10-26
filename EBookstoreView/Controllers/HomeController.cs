using BussinessObjects;
using EBookstoreView.Helpers;
using EBookstoreView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace EBookstoreView.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string USER = "user";
        private readonly string ROLE = "role";
        private readonly string UserApiUrl = "";
        private readonly HttpClient client = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            UserApiUrl = "https://localhost:7000/api/Users";
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(User loginUser)
        {
            ValidateLoginAsync(loginUser);
            if (!ModelState.IsValid)
            {
                return View();
            }

            var isAdmin = (loginUser.Email == GetAdminUsername() && loginUser.Password == GetAdminPassword());

            if (isAdmin)
            {
                SessionHelper.SetObjectAsJson(HttpContext.Session, USER, loginUser);
                HttpContext.Session.SetString(ROLE, "admin");
                return RedirectToAction("Index", "Books");
            }
            else
            {
                var userLists = await client.GetFromJsonAsync<List<User>>(UserApiUrl);
                var loginCustomer = userLists.FirstOrDefault(x => x.Email == loginUser.Email && x.Password == loginUser.Password);
                loginCustomer.Password = null;
                SessionHelper.SetObjectAsJson(HttpContext.Session, USER, loginCustomer);
                HttpContext.Session.SetString(ROLE, "customer");
                return RedirectToAction("Index", "Books");
            }
        }

        public async Task ValidateLoginAsync(User loginUser)
        {
            ModelState.Clear();
            if (string.IsNullOrEmpty(loginUser.Email)) ModelState.AddModelError("LoginUser.Email", "Email cannot be null");
            if (string.IsNullOrEmpty(loginUser.Password)) ModelState.AddModelError("LoginUser.Password", "Email cannot be null");

            var adminEmail = GetAdminUsername();
            var adminPassword = GetAdminPassword();
            var isAdmin = (loginUser.Email == adminEmail && loginUser.Password == adminPassword);
            var userLists = await client.GetFromJsonAsync<List<User>>(UserApiUrl);
            var existingUser = userLists.Any(x => x.Email == loginUser.Email && x.Password == loginUser.Password);
            var hasAccount = (isAdmin) || (existingUser);

            if (!hasAccount)
            {
                ModelState.AddModelError("LoginUser.Email", "User not exist");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            var loginUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            if (loginUser == null)
            {
                return RedirectToAction("/Index");
            }
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("role");
            return RedirectToAction("Index", "Home");
        }

        private string GetAdminUsername()
        {
            IConfiguration config = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", true, true)
                  .Build();
            return config["adminAccount:username"];
        }

        private string GetAdminPassword()
        {
            IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
            return config["adminAccount:password"];
        }
    }
}
