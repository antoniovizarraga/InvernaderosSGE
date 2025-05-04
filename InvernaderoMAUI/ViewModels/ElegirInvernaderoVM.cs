using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using BL;
using ENT;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

namespace InvernaderoMAUI.ViewModels
{
    public class ElegirInvernaderoVM : INotifyPropertyChanged
    {
        #region Variables

        private Dictionary<string, object> datosAPasar = new Dictionary<string, object>();

        private bool errorAlert = false;

        private ClsInvernadero invernaderoSeleccionado;

        #endregion


        #region Propiedades
        public List<ClsInvernadero> ListadoInvernaderos { get; }

        public DateTime FechaSeleccionada { get; set; }

        public DelegateCommand ConfirmarCommand { get; }

        public ClsInvernadero InvernaderoSeleccionado
        {
            get { return invernaderoSeleccionado; }
            set { invernaderoSeleccionado = value; ConfirmarCommand.RaiseCanExecuteChanged(); }
        }

        // Este bool es para mostrar un texto de error en la vista si la fecha seleccionada no existe en la BBDD.
        public bool ErrorAlert
        { 
            get { return errorAlert; }
            set { errorAlert = value; NotifyPropertyChanged("ErrorAlert"); }
        }

        // Esto lo hacemos para que el usuario no pueda elegir una fecha a futuro, ya que no tiene sentido.
        public DateTime FechaActual { get; }

        #endregion

        #region Constructor

        public ElegirInvernaderoVM()
        {
            ConfirmarCommand = new DelegateCommand(ConfirmarCommand_Execute, ConfirmarCommand_CanExecute);
            FechaActual = DateTime.Now.Date;
            InvernaderoSeleccionado = new ClsInvernadero(0, "");
            FechaSeleccionada = FechaActual;

            try
            {
                ListadoInvernaderos = ListadoInvernaderosBL.ObtenerListadoInvernaderos();
            }
            catch (Exception ex)
            {
                errorAlert = true;
            }

        }

        #endregion


        #region Métodos

        private void ConfirmarCommand_Execute()
        {
            if (!ManejadoraDtoBL.ComprobarSiFechaDeTemperaturaExiste(invernaderoSeleccionado.Id, FechaSeleccionada))
            {
                ErrorAlert = true;
            } else
            {
                // Esto lo hacemos para que por si había ya datos anteriores que se hayan quedado en memoria en el diccionario, los borramos de antemano.
                // Esto ocurriría en el caso de que el usuario decidiera volver atrás y seleccionar otro invernadero con otra fecha.
                datosAPasar.Clear();
                datosAPasar.Add("nombreElegido", InvernaderoSeleccionado);
                datosAPasar.Add("fechaElegida", FechaSeleccionada.Date);
                errorAlert = false;
                CambiarPagina("///MostrarTemperatura", datosAPasar);
            }
        }

        private bool ConfirmarCommand_CanExecute()
        {
            bool res = false;

            if (InvernaderoSeleccionado.Nombre != "")
            {
                res = true;
            }

            return res;
        }

        /// <summary>
        /// Función privada que se encarga de cambiar páginas con el nombre de la página especificada
        /// por parámetro, para luego enviar todos los datos que quieras a través de un diccionario
        /// (Cómo especifica la documentación oficial):
        /// https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/navigation?view=net-maui-8.0
        /// </summary>
        /// <param name="pagina">El nombre de la página a la que cambiar. Al principio debe tener estas letras: "///".</param>
        /// <param name="objetoAPasar">El diccionario que contendrá todos los datos u objetos que queramos pasar.</param>
        private async void CambiarPagina(string pagina, Dictionary<string, object> objetoAPasar)
        {
            await Shell.Current.GoToAsync(pagina, false, objetoAPasar);
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
