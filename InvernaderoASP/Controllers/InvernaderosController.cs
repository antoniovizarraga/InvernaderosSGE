using BL;
using DTO;
using ENT;
using Microsoft.AspNetCore.Mvc;

namespace InvernaderoASP.Controllers
{
    public class InvernaderosController : Controller
    {
        public ActionResult Index()
        {
            // Hago esto para evitar tener que hacer varios returns en la misma función dependiendo
            // de la circunstancia. Pregunté a ChatGPT (Sin pasar nada de código; sólo he preguntado)
            // cómo evitar tener que hacer varios returns en una misma función de un controlador de
            // MVC en ASP.NET, ya que este caso se suele ver mucho. Elena en primero siempre nos
            // daba mucha caña con evitar los returns innecesarios.
            ActionResult res;

            List<ClsInvernadero> listadoInvernaderos = new List<ClsInvernadero>();

            try
            {
                listadoInvernaderos = ListadoInvernaderosBL.ObtenerListadoInvernaderos();
                res = View(listadoInvernaderos);
            }
            catch (Exception ex)
            {
                res = View("Error");
            }

            return res;
        }

        // POST: InvernaderosController
        [HttpPost]
        public ActionResult Informacion(int idInvernadero, DateTime fechaSeleccionada)
        {
            // Esto lo hacemos por si el usuario ha elegido un invernadero que no es correcto. En cuyo caso, enviamos
            // de vuelta dicho listado a la página.
            List<ClsInvernadero> listadoInvernaderos = new List<ClsInvernadero>();
            
            ActionResult res;
            bool invernaderoExiste = false;
            ClsTemperaturaConNombreInvernadero invernaderoAEnviar;





            try
            {
                invernaderoExiste = ManejadoraDtoBL.ComprobarSiFechaDeTemperaturaExiste(idInvernadero, fechaSeleccionada);      
            }
            catch (Exception ex)
            {
                res = View("Error");
            }

            if(invernaderoExiste)
            {
                try
                {
                    invernaderoAEnviar = ManejadoraDtoBL.BuscarTemperaturaConNombrePorFecha(idInvernadero, fechaSeleccionada);
                    res = View(invernaderoAEnviar);
                }
                catch (Exception ex) 
                {
                    res = View("Error");
                }
            } else {
                ViewBag.ErrorPagina = "No existe un invernadero con la fecha seleccionada.";
                listadoInvernaderos = ListadoInvernaderosBL.ObtenerListadoInvernaderos();
                res = View("Index", listadoInvernaderos);

            }

            return res;

        }
    }
}
