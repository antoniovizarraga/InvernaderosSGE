
using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using BL;
using DTO;
using ENT;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;

namespace InvernaderoMAUI.ViewModels
{
    public class MostrarTemperaturaVM : INotifyPropertyChanged, IQueryAttributable
    {

        #region Variables

        private ClsInvernadero invernaderoRecibido;

        private DateTime? fechaRecibida;


        #endregion

        #region Propiedades

        public DelegateCommand VolverCommand { get; private set; }

        public ClsTemperaturaConNombreInvernadero InvernaderoInfo { get; private set; }

        public ClsInvernadero InvernaderoRecibido { get { return invernaderoRecibido; } }

        public DateTime? FechaRecibida { get { return fechaRecibida; } }

        #endregion

        #region Constructor

        /* IMPORTANTE: No he usado este constructor porque ya usé la función ApplyQueryAttributes como: "Constructor", ya que se ejecuta
         * de manera automática al recibir datos. Puede encontrar más información aquí:
         * https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/navigation?view=net-maui-8.0#process-navigation-data-using-a-single-method */

        public MostrarTemperaturaVM()
        {
            VolverCommand = new DelegateCommand(VolverCommand_Execute);
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Función privada que se encarga de cambiar páginas con el nombre de la página especificada
        /// por parámetro.
        /// </summary>
        /// <param name="pagina">El nombre de la página a la que cambiar. Al principio debe tener estas letras: "///".</param>
        private async void CambiarPagina(string pagina)
        {
            await Shell.Current.GoToAsync(pagina);
        }


        private void VolverCommand_Execute()
        {
            CambiarPagina("//ElegirInvernadero");
        }

        /* Función que cuando .NET MAUI detecta que ha recibido un objeto por parámetro de forma automática, se ejecuta automáticamente.
         * Esto funciona como un: "Constructor" a nivel de código. Que se activa cada vez que recibe datos. */
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {

            invernaderoRecibido = query["nombreElegido"] as ClsInvernadero;

            // Tuve que ponerlo así porque si no salta un error diciendo que DateOnly no es un tipo que acepte null.
            fechaRecibida = query["fechaElegida"] as DateTime?;

            InvernaderoInfo = ManejadoraDtoBL.BuscarTemperaturaConNombrePorFecha(invernaderoRecibido.Id, fechaRecibida.Value);


            


            NotifyPropertyChanged("InvernaderoInfo");
            NotifyPropertyChanged("FechaRecibida");

            // Hacemos esto porque por lo visto, puede dar fallos en otras vistas.
            query.Clear();
        }

        #endregion

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName = "")

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion

        


    }
}
