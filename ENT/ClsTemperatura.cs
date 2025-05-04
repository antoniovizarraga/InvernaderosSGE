namespace ENT
{
    public class ClsTemperatura
    {
        #region Propiedades

        public int IdInvernadero { get; }

        public DateOnly Fecha { get; }

        /* Hacemos todas estas propiedades null porque puede ocurrir que una
         * temperatura no sea registrada correctamente cómo indica el
         * ejercicio. Habrá que tener MUCHO cuidado con esto, ya que
         * esto puede dar lugar a muchos errores de código y
         * excepciones a futuro. */
        public double? Temp1 { get; set; }

        public double? Temp2 { get; set; }

        public double? Temp3 { get; set; }

        public double? Humedad1 { get; set; }

        public double? Humedad2 { get; set; }

        public double? Humedad3 { get; set; }

        #endregion


        #region Constructores

        public ClsTemperatura(int IdInvernadero, DateOnly Fecha)
        {
            this.IdInvernadero = IdInvernadero;
            this.Fecha = Fecha;
        }

        /* Quizás este constructor sobre, debido a que esto sólo se usa para la función de la capa DAL:
         * "ObtenerListadoTemperaturas", y dicho listado según intuyo, no hace falta. Mejor que sobre
         * a que no falte. :) */
        public ClsTemperatura(int IdInvernadero, DateOnly Fecha, double? Temp1, double? Temp2, double? Temp3, double? Humedad1, double? Humedad2, double? Humedad3)
        {
            this.IdInvernadero = IdInvernadero;
            this.Fecha = Fecha;
            this.Temp1 = Temp1;
            this.Temp2 = Temp2;
            this.Temp3 = Temp3;
            this.Humedad1 = Humedad1;
            this.Humedad2 = Humedad2;
            this.Humedad3 = Humedad3;
        }

        #endregion
    }
}
