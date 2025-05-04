using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using ENT;

namespace InvernaderoMAUI.ViewModels
{
    public class ElegirInvernaderoVM
    {
        #region Propiedades
        public List<ClsInvernadero> ListadoInvernaderos { get; }

        public ClsInvernadero InvernaderoSeleccionado {  get; set; }

        public DateOnly FechaSeleccionada { get; set; }

        public DelegateCommand ConfirmarCommand { get; }

        #endregion

        #region Constructor

        public ElegirInvernaderoVM()
        {
            InvernaderoSeleccionado = new ClsInvernadero(0, "");
            FechaSeleccionada = new DateOnly();
            ConfirmarCommand = new DelegateCommand(ConfirmarCommand_Execute, ConfirmarCommand_CanExecute);
        }

        #endregion


        #region Métodos

        private void ConfirmarCommand_Execute()
        {

        }

        private bool ConfirmarCommand_CanExecute()
        {
            bool res = false;



            return res;
        }

        #endregion
    }
}
