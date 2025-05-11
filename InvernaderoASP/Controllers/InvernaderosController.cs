using Microsoft.AspNetCore.Mvc;

namespace InvernaderoASP.Controllers
{
    public class InvernaderosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // POST: InvernaderosController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IFormCollection collection)
        {
            //TODO: Hacer que la vista retorne un NotFound si no existe el invernadero con la fecha seleccionada. O hacerlo por un ViewBag.
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
