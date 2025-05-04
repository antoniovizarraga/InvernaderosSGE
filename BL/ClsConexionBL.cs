using DAL;

namespace BL
{
    public class ClsConexionBL
    {
        /// <summary>
        /// Función que devuelve una cadena de conexión para conectarnos a la BBDD.
        /// </summary>
        /// <returns>Un <see langword="string"/> que contiene la cadena de conexión necesaria para conectarnos a la base de datos.</returns>
        public static string GetConnectionString()
        {
            return ClsConectionBD.GetConnectionString();
        }
    }
}
