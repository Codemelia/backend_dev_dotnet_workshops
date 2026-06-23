using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;

namespace _3b_dotnet_webapp.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index(string name)
        {
            if (name != null)
                ViewBag.name = name;
            else ViewBag.name = "User";
            return View();
        }
    }
}
