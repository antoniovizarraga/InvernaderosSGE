using DTO;
using ENT;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class ManejadoraDTO
    {
        /* No se podría hacer una función que reduzca el código redundante en estas dos funciones de abajo,
         * ya que aunque el código es el mismo, no devuelven lo mismo. Uno da un bool, mientras que otro
         * devuelve lo que encuentre en la BBDD según la consulta SQL. 
         * 
         * Estaba pensando también en que quizás, cómo la función: "ComprobarSiFechaDeTemperaturaExiste"
         * es necesaria para la vista para informar al usuario de que el invernadero seleccionado con
         * la fecha seleccionada no existe, quizás hacer que esa función sea pública pero creando
         * aparte una función que ejecute las dos funciones dependiendo de si el bool que devuelve
         * ComprobarSiFechaDeTemperaturaExiste es true o false, poniendo la función que devuelve
         * la temperatura privada. Y así hacemos quizá más legible las funciones para el:
         * "becario". Pero no sé si estoy dando más vueltas de lo necesario a esto.
         */

        /// <summary>
        /// Función que sirve para saber si una fila en la BBDD existe con una fecha (<see cref="DateTime"/>) proporcionada por parámetro.
        /// Esto sirve para que en la vista, muestre el error correspondiente al usuario para informarle de si
        /// existe un invernadero con la fecha o no.
        /// Pre: La fecha debe estar registrada en la tabla Temperaturas. Si no, la función
        /// devolverá <see langword="false"/>. O <see langword="true"/> en caso contrario. Post: Ninguna.
        /// </summary>
        /// <param name="idDepartamento">El departamento para comprobar si la fecha especificada coincide con la del apartamento.</param>
        /// <param name="fecha">La fecha a buscar en la BBDD para saber si existe una temperatura con dicha fecha.</param>
        /// <returns>Un <see langword="bool"/> indicando si la fecha existe en la BBDD. Devolverá <see langword="true"/> si lo encuentra.
        /// Si no, devolverá <see langword="false"/>.</returns>
        public static bool ComprobarSiFechaDeTemperaturaExiste(int idDepartamento, DateTime fecha)
        {
            bool res = false;

            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            /* Revisar esta línea de código más tarde, ya que igual convertir un tipo Date en SQL Server a DateOnly
             * puede dar problemas según la documentación: */
            // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-type-conversion-database-engine?view=sql-server-ver16
            miComando.Parameters.Add("@fechaSeleccionada", SqlDbType.Date).Value = fecha.ToString("yyyy-dd-MM");
            miComando.Parameters.Add("@idDepar", SqlDbType.Int).Value = idDepartamento;



            miConexion.ConnectionString = ClsConectionBD.GetConnectionString();

            try
            {
                miConexion.Open();

                /* Consulta SQL con un JOIN de las dos tablas para que nos devuelva una fila con la fecha que se nos pasa por parámetro. */
                miComando.CommandText = "SELECT i.nombre, t.idInvernadero, t.fecha, t.temp1, t.temp2, t.temp3, t.humedad1, t.humedad2, t.humedad3 FROM Temperaturas AS t INNER JOIN Invernaderos AS i ON t.idInvernadero = i.idInvernadero WHERE t.idInvernadero = @idDepar AND t.fecha = @fechaSeleccionada";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();


                // Si hay líneas en el lector

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        if (!miLector.IsDBNull("fecha"))
                        {
                            // Si no es nulo la fecha, indica que una temperatura con una determinada fecha existe.
                            res = true;
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



            return res;
        }


        /// <summary>
        /// Función que se encarga de conectarse a la BBDD para buscar una temperatura (<see cref="ClsTemperaturaConNombreInvernadero"/>) que pertenezca a un invernadero con una fecha
        /// (<see cref="DateTime"/>) pasada por parámetro.
        /// Pre: La fecha debe ser de la de una temperatura que exista en la BBDD. Post: Devuelve un <see cref="ClsTemperaturaConNombreInvernadero"/>
        /// relleno de valores que encuentre en la BBDD. Si no lo encuentra, puede que devuelva null o un objeto vacío.
        /// ADVERTENCIA: Puede que contenga datos como: "temp1" que estén nulos (Porque no registre una temperatura
        /// correctamente). De ser así, en la vista asegúrate de que ponga un: "?" en dicho caso.
        /// </summary>
        /// <param name="idDepartamento">El departamento para comprobar si la fecha especificada coincide con la del apartamento.</param>
        /// <param name="fecha">La fecha por la que buscar en la BBDD una temperatura.</param>
        /// <returns>Un <see cref="ClsTemperaturaConNombreInvernadero"/> relleno con valores que encuentre en la BBDD. Si no
        /// lo encuentra, puede estar nulo o vacío.</returns>
        public static ClsTemperaturaConNombreInvernadero BuscarTemperaturaConNombrePorFecha(int idDepartamento, DateTime fecha)
        {
            ClsTemperaturaConNombreInvernadero temperaturaConNombre = new ClsTemperaturaConNombreInvernadero("", 0, DateTime.Now.Date);


            SqlConnection miConexion = new SqlConnection();

            SqlCommand miComando = new SqlCommand();

            SqlDataReader miLector;

            /* Revisar esta línea de código más tarde, ya que igual convertir un tipo Date en SQL Server a DateOnly
             * puede dar problemas según la documentación: */
            // https://learn.microsoft.com/en-us/sql/t-sql/data-types/data-type-conversion-database-engine?view=sql-server-ver16
            miComando.Parameters.Add("@fechaSeleccionada", System.Data.SqlDbType.Date).Value = fecha.ToString("yyyy-dd-MM");
            miComando.Parameters.Add("@idDepar", SqlDbType.Int).Value = idDepartamento;


            miConexion.ConnectionString = ClsConectionBD.GetConnectionString();

            try
            {
                miConexion.Open();

                /* Consulta SQL con un JOIN de las dos tablas para que nos devuelva una fila con la fecha que se nos pasa por parámetro. */
                miComando.CommandText = "SELECT i.nombre, t.idInvernadero, t.fecha, t.temp1, t.temp2, t.temp3, t.humedad1, t.humedad2, t.humedad3 FROM Temperaturas AS t INNER JOIN Invernaderos AS i ON t.idInvernadero = i.idInvernadero WHERE t.idInvernadero = @idDepar AND t.fecha = @fechaSeleccionada";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();


                // Si hay líneas en el lector

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        /* Esto he tenido que hacerlo porque un campo nulo en base de datos no es igual a un null en código. */
                        // Dios mío...
                        temperaturaConNombre = new ClsTemperaturaConNombreInvernadero(
                            (string)miLector["nombre"],
                            (int)miLector["idInvernadero"],
                            (DateTime)miLector["fecha"],

                            miLector["temp1"] == DBNull.Value ? null : (double?)miLector["temp1"],
                            miLector["temp2"] == DBNull.Value ? null : (double?)miLector["temp2"],
                            miLector["temp3"] == DBNull.Value ? null : (double?)miLector["temp3"],

                            miLector["humedad1"] == DBNull.Value ? null : (double?)miLector["humedad1"],
                            miLector["humedad2"] == DBNull.Value ? null : (double?)miLector["humedad2"],
                            miLector["humedad3"] == DBNull.Value ? null : (double?)miLector["humedad3"]
                        );

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
