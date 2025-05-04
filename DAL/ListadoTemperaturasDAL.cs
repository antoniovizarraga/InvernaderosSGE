using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListadoTemperaturasDAL
    {
        /// <summary>
        /// Función que se encarga de realizar una conexión con la base de datos y devuelve un <see cref="List{ClsTemperatura}"/> relleno de temperaturas, para luego cerrar dicha conexión.
        /// Pre: Nada. Post: Devuelve un <see cref="List{ClsTemperatura}"/> con objetos de tipo <see cref="ClsTemperatura"/>.
        /// </summary>
        /// <returns>Un <see cref="List{ClsTemperatura}"/> relleno con objetos de tipo <see cref="ClsTemperatura"/>. Estará vacío si en la BBDD no hay datos.</returns>
        public static List<ClsTemperatura> ObtenerListadoTemperaturas()
        {
            SqlConnection miConexion = new SqlConnection();

            List<ClsTemperatura> listadoTemperaturas = new List<ClsTemperatura>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsTemperatura temperatura;

            miConexion.ConnectionString = ClsConectionBD.GetConnectionString();

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Temperaturas";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();


                // Si hay líneas en el lector

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                            
                                /* Muy seguramente este código no haga falta. Dudo muchísimo que haya que hacer
                                 * un constructor así de tocho. Revisar esto más tarde por si hiciera falta
                                 * borrar todo esto. */

                                temperatura = new ClsTemperatura((int)miLector["idInvernadero"], (DateTime)miLector["fecha"], 
                                (double?)miLector["temp1"], (double?)miLector["temp2"], (double?)miLector["temp3"],
                                (double?)miLector["humedad1"], (double?)miLector["humedad2"], (double?)miLector["humedad3"]);

                            listadoTemperaturas.Add(temperatura);


                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return listadoTemperaturas;


        }
    }
}
