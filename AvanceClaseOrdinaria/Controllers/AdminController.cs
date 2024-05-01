using Microsoft.AspNetCore.Mvc;

namespace AvanceClaseOrdinaria.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult InicioAdmin()
        {
            return View();
        }
    }
}
