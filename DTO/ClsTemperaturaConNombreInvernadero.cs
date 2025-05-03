using ENT;

namespace DTO
{
    public class ClsTemperaturaConNombreInvernadero : ClsTemperatura
    {
        public string Nombre { get; }

        public ClsTemperaturaConNombreInvernadero(int IdInvernadero, DateOnly Fecha) : base(IdInvernadero, Fecha)
        {
            //TODO: ¿Quizás usar método de la BL para que por defecto en el constructor le asigne el nombre que tenga en la BBDD?
        }

        public ClsTemperaturaConNombreInvernadero(string Nombre, int IdInvernadero, DateOnly Fecha) : base(IdInvernadero, Fecha)
        {
            this.Nombre = Nombre;
        }
    }
}
