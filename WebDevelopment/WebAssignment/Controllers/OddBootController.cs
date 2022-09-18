using Microsoft.AspNetCore.Mvc;
using WebAssignment.Models;

namespace WebAssignment.Controllers
{
    public class OddBootController : Controller
    {
        public IActionResult PrintNumbers()
        {
            return View();
        }
        public IActionResult Table()
        {
            student student1 = new()
            {
                Name"prigesh",
                email=dfjdfj@gaajh.com
                add
            }
            List<student> names = new() { "priges", "names", "bishnu" };
            return View(names);
        }
    }
}
