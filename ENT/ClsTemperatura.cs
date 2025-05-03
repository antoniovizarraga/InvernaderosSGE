namespace ENT
{
    public class ClsTemperatura
    {
        #region Propiedades

        public int IdInvernadero { get; }

        public DateOnly Fecha { get; }

        public double Temp1 { get; }

        public double Temp2 { get; }

        public double Temp3 { get; }

        public double Humedad1 { get; }

        public double Humedad2 { get; }

        public double Humedad3 { get; }

        #endregion


        #region Constructores

        public ClsTemperatura(int IdInvernadero, DateOnly Fecha)
        {
            this.IdInvernadero = IdInvernadero;
            this.Fecha = Fecha;
        }

        #endregion
    }
}
