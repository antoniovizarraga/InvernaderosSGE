
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

        private string temperatura1 = "?";

        private string temperatura2 = "?";

        private string temperatura3 = "?";

        private string humedad1 = "?";

        private string humedad2 = "?";

        private string humedad3 = "?";


        #endregion

        #region Propiedades

        public DelegateCommand VolverCommand { get; private set; }

        public ClsTemperaturaConNombreInvernadero InvernaderoInfo { get; private set; }

        public ClsInvernadero InvernaderoRecibido { get { return invernaderoRecibido; } }

        public DateTime? FechaRecibida { get { return fechaRecibida; } }

        public string Temperatura1 {
            get { return temperatura1; } 
            set { 
                if(!string.IsNullOrEmpty(value))
                {
                    temperatura1 = value;
                }
            }
        }

        public string Temperatura2
        {
            get { return temperatura2; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    temperatura2 = value;
                }
            }
        }

        public string Temperatura3
        {
            get { return temperatura3; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    temperatura3 = value;
                }
            }
        }

        public string Humedad1
        {
            get { return humedad1; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    humedad1 = value;
                }
            }
        }

        public string Humedad2
        {
            get { return humedad2; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    humedad2 = value;
                }
            }
        }

        public string Humedad3
        {
            get { return humedad3; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    humedad3 = value;
                }
            }
        }

        #endregion

        #region Constructor

        /* IMPORTANTE: No hice constructor porque la única forma que tendría esta vista de renderizarse es cuando la BBDD ya ha verificado
         * de antemano en la anterior vista que la fecha ya existe. Si ya existe, significa por tanto que se puede mostrar información 
         * de la temperatura con el nombre del Invernadero correctamente. La función: "ApplyQueryAttributes" ya actúa cómo:
         * "Constructor" por así decirlo, ya que cuando .NET MAUI detecta que ha recibido datos al cambiar a esta vista,
         * se ejecuta el código dentro de la función automáticamente. No sé si en este caso me he columpiado demasiado
         * al quitar el Constructor del ViewModel. Soy consciente de que SIEMPRE en los ViewModels estas cosas hay que
         * hacerlas con el constructor, respetando la arquitectura MVVM. Pero cómo no he sabido qué hacer en este
         * caso (Debido a que un constructor y un ApplyQueryAttributes no pueden coexistir ambas a la vez),
         * pues he usado la función que ya he especificado como: "Constructor". Puede leer sobre esto más
         * en la documentación, aquí:
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


            Temperatura1 = InvernaderoInfo.Temp1.ToString();
            Temperatura2 = InvernaderoInfo.Temp2.ToString();
            Temperatura3 = InvernaderoInfo.Temp3.ToString();
            Humedad1 = InvernaderoInfo.Humedad1.ToString();
            Humedad2 = InvernaderoInfo.Humedad2.ToString();
            Humedad3 = InvernaderoInfo.Humedad3.ToString();


            NotifyPropertyChanged("InvernaderoInfo");
            NotifyPropertyChanged("FechaRecibida");
            NotifyPropertyChanged("Temperatura1");
            NotifyPropertyChanged("Temperatura2");
            NotifyPropertyChanged("Temperatura3");
            NotifyPropertyChanged("Humedad1");
            NotifyPropertyChanged("Humedad2");
            NotifyPropertyChanged("Humedad3");

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
