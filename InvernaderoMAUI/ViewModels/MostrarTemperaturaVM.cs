
using DTO;
using ENT;
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

        public ClsTemperaturaConNombreInvernadero InvernaderoInfo { get; }

        public ClsInvernadero InvernaderoRecibido { get { return invernaderoRecibido; } }

        public DateTime? FechaRecibida { get { return fechaRecibida; } }

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

        #endregion

        #region Métodos

        /* Función que cuando .NET MAUI detecta que ha recibido un objeto por parámetro de forma automática, se ejecuta automáticamente.
         * Esto funciona como un: "Constructor" a nivel de código. Que se activa cada vez que recibe datos. */
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            //TODO
            /* 
             *
             *
             *  YourObject = query["YourKey"] as YourObjectType;
             *  OnPropertyChanged("YourObject");
             *
             *
             *
             */

            invernaderoRecibido = query["nombreElegido"] as ClsInvernadero;

            // Tuve que ponerlo así porque si no salta un error diciendo que DateOnly no es un tipo que acepte null.
            fechaRecibida = query["fechaElegida"] as DateTime?;

            NotifyPropertyChanged("InvernaderoRecibido");
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
