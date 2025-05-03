namespace ENT
{
    public class ClsInvernadero
    {
        #region Propiedades
        public int Id { get; }

        public string Nombre { get; }

        #endregion

        #region Constructores

        public ClsInvernadero(int Id, string Nombre)
        {
            this.Id = Id;
            this.Nombre = Nombre;
        }
        
        #endregion
    }
}
