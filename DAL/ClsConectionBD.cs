namespace DAL
{
    public class ClsConectionBD
    {
        /// <summary>
        /// Función que devuelve una cadena de conexión para conectarnos a la BBDD.
        /// </summary>
        /// <returns>Un <see langword="string"/> que contiene la cadena de conexión necesaria para conectarnos a la base de datos.</returns>
        public static string GetConnectionString()
        {
            return "server=avizarraga.database.windows.net;database=AntonioDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
        }
    }
}
