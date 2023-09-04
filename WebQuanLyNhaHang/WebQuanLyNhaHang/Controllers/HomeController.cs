using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _dataContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //About
        public IActionResult About()
        {
            return View();
        }


        //Menu
        public IActionResult Menu()
        {
            return View();
        }

        //Contact
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        //Action thêm Contact vào CSDL
        public IActionResult Contact(Contact ct)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Contacts.Add(ct);
                _dataContext.SaveChanges();
                return RedirectToAction("Contact");
            }
            return View(ct);
        }

        //Employee
        public IActionResult Employee()
        {
            return View();
        }

        //Booking
        public IActionResult Booking()
        {
            return View();
        }
        [HttpPost]
        //Action thêm Booking vào CSDL
        public IActionResult Booking(Order od)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Orders.Add(od);
                _dataContext.SaveChanges();
                return RedirectToAction("Booking");
            }
            return View(od);
        }
        //Action Details
        [Route("/post-{slug}-{id:long}.html", Name = "Details")]

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _dataContext.Posts
                .FirstOrDefault(m => (m.PostID == id) && (m.IsActive == true));
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
        
        //Action FoodDetail
        [Route("/info-{slug}-{id:long}.html", Name = "FoodDetails")]

        public IActionResult FoodDetails(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var info = _dataContext.ViewFoodDetails
                .FirstOrDefault(f => (f.FoodID == id) && (f.IsActive == true));
            if (info == null)
            {
                return NotFound();
            }
            return View(info);
        }
        //Action Profile
        [Route("/profile-{slug}-{id:long}.html", Name = "EmployeeProfile")]

        public IActionResult EmployeeProfile(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var profile = _dataContext.Employees
                .FirstOrDefault(f => (f.EmployeeID == id) && (f.IsActive == true));
            if (profile == null)
            {
                return NotFound();
            }
            return View(profile);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}