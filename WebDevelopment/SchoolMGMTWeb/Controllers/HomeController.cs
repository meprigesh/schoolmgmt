using Microsoft.AspNetCore.Mvc;
using SchoolMGMTWeb.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SchoolMGMTWeb.Controllers
{
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

        private static List<(int Id,string FirstName,String LastName,string Address)>GetStudents()
        {
            List<(int Id, string FirstName, string LastName, string Address)> student = new List<(int Id, string FirstName, string LastName, string Address)>();
            string connectionString= @"Data Source=(localdb)\schoollocaldb;Initial Catalog=testdb;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            // string "query" = "select * from student";
            return student;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}