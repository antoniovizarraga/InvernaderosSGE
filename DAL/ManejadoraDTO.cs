using DTO;
using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ManejadoraDTO
    {
        /// <summary>
        /// Función que se encarga de conectarse a la BBDD para comprobar si una temperatura existe.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public ClsTemperaturaConNombreInvernadero BuscarTemperaturaConNombrePorFecha(string nombre, DateOnly fecha)
        {
            ClsTemperaturaConNombreInvernadero temperaturaConNombre = new ClsTemperaturaConNombreInvernadero("", 0, DateOnly.FromDateTime(DateTime.Now.Date));


            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            /* Revisar esta línea de código más tarde, ya que igual convertir un tipo Date en SQL Server a DateOnly
             * puede dar problemas según la documentación: */
            // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-type-conversion-database-engine?view=sql-server-ver16
            miComando.Parameters.Add("@fechaSeleccionada", System.Data.SqlDbType.Date).Value = fecha;

            miConexion.ConnectionString = ClsConectionBD.GetConnectionString();

            try
            {
                miConexion.Open();

                /* Consulta SQL con un JOIN de las dos tablas para que nos devuelva una fila con la fecha que se nos pasa por parámetro. */
                miComando.CommandText = "SELECT i.nombre, t.idInvernadero, t.fecha, t.temp1, t.temp2, t.temp3, t.humedad1, t.humedad2, t.humedad3 FROM Temperaturas AS t INNER JOIN Invernaderos AS i ON t.idInvernadero = i.idInvernadero WHERE t.fecha = @fechaSeleccionada";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();


                // Si hay líneas en el lector

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        /* Revisar esta línea de código más tarde, ya que igual convertir un tipo Date en SQL Server a DateOnly
                         * puede dar problemas según la documentación: */
                        // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-type-conversion-database-engine?view=sql-server-ver16
                        temperaturaConNombre = new ClsTemperaturaConNombreInvernadero((string)miLector["nombre"], (int)miLector["idInvernadero"], (DateOnly)miLector["fecha"],
                            (double?)miLector["temp1"], (double?)miLector["temp2"], (double?)miLector["temp3"],
                            (double?)miLector["humedad1"], (double?)miLector["humedad2"], (double?)miLector["humedad3"]);

                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }





            return temperaturaConNombre;
        }
    }
}
