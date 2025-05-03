namespace ENT
{
    public class ClsTemperatura
    {
        #region Propiedades

        public int IdInvernadero { get; }

        public DateOnly Fecha { get; }

        public double Temp1 { get; set; }

        public double Temp2 { get; set; }

        public double Temp3 { get; set; }

        public double Humedad1 { get; set; }

        public double Humedad2 { get; set; }

        public double Humedad3 { get; set; }

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
