using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ListadoInvernaderosDAL
    {
        /// <summary>
        /// Función que se encarga de realizar una conexión con la base de datos y devuelve un <see cref="List{ClsInvernadero}"/> relleno de invernaderos, para luego cerrar dicha conexión.
        /// Pre: Nada. Post: Devuelve un <see cref="List{ClsInvernadero}"/> con objetos de tipo <see cref="ClsInvernadero"/>.
        /// </summary>
        /// <returns>Un <see cref="List{ClsInvernadero}"/> relleno con objetos de tipo <see cref="ClsInvernadero"/>. Estará vacío si en la BBDD no hay datos.</returns>
        public static List<ClsInvernadero> ObtenerListadoPersonajes()
        {
            SqlConnection miConexion = new SqlConnection();

            List<ClsInvernadero> listadoInvernaderos = new List<ClsInvernadero>();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            ClsInvernadero invernadero;

            miConexion.ConnectionString = ClsConectionBD.GetConnectionString();

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM Invernaderos";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();


                // Si hay líneas en el lector

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {

                        if ((int)miLector["idInvernadero"] != null || !string.IsNullOrEmpty((string)miLector["idInvernadero"]))
                        {
                            // Quizás se podría hacer un sólo constructor de Personaje con el ID, para así no tener que hacerlo todo en una única línea.
                            invernadero = new ClsInvernadero((int)miLector["idInvernadero"], (string)miLector["idInvernadero"]);

                            listadoInvernaderos.Add(invernadero);

                        }



                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return listadoInvernaderos;


        }

    }
}
