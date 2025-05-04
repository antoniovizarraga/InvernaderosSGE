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
        public static List<ClsInvernadero> ObtenerListadoInvernaderos()
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

                        /* Cómo en la BBDD estos campos no pueden ser nulos (El ID es la PK que además es Identity, y
                         * el nombre es not null (No tiene sentido registrar un Invernadero que no tiene nombre),
                         * no compruebo que no sean nulos porque ya en la BBDD siempre va a tener un valor de
                         * antemano. */

                        invernadero = new ClsInvernadero((int)miLector["idInvernadero"], (string)miLector["nombre"]);

                        listadoInvernaderos.Add(invernadero);

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
