using DAL;
using DTO;

namespace BL
{
    public class ManejadoraDtoBL
    {
        /// <summary>
        /// Función que sirve para saber si una fila en la BBDD existe con una fecha (<see cref="DateTime"/>) proporcionada por parámetro.
        /// Esto sirve para que en la vista, muestre el error correspondiente al usuario para informarle de si
        /// existe un invernadero con la fecha o no.
        /// Pre: La fecha debe estar registrada en la tabla Temperaturas. Si no, la función
        /// devolverá <see langword="false"/>. O <see langword="true"/> en caso contrario. Post: Ninguna.
        /// </summary>
        /// <param name="idInvernadero">El Id del Invernadero para comprobar si la temperatura existe con un Invernadero y una fecha dada.</param>
        /// <param name="fecha">La fecha a buscar en la BBDD para saber si existe una temperatura con dicha fecha.</param>
        /// <returns>Un <see langword="bool"/> indicando si la fecha existe en la BBDD. Devolverá <see langword="true"/> si lo encuentra.
        /// Si no, devolverá <see langword="false"/>.</returns>
        public static bool ComprobarSiFechaDeTemperaturaExiste(int idInvernadero, DateTime fecha)
        {
            return ManejadoraDTO.ComprobarSiFechaDeTemperaturaExiste(idInvernadero, fecha.Date);
        }

        /// <summary>
        /// Función que se encarga de conectarse a la BBDD para buscar una temperatura (<see cref="ClsTemperaturaConNombreInvernadero"/>) que pertenezca a un invernadero con una fecha
        /// (<see cref="DateTime"/>) pasada por parámetro.
        /// Pre: La fecha debe ser de la de una temperatura que exista en la BBDD. Post: Devuelve un <see cref="ClsTemperaturaConNombreInvernadero"/>
        /// relleno de valores que encuentre en la BBDD. Si no lo encuentra, puede que devuelva null o un objeto vacío.
        /// ADVERTENCIA: Puede que contenga datos como: "temp1" que estén nulos (Porque no registre una temperatura
        /// correctamente). De ser así, en la vista asegúrate de que ponga un: "?" en dicho caso.
        /// </summary>
        /// <param name="idInvernadero">El Id del Invernadero para comprobar si la temperatura existe con un Invernadero y una fecha dada.</param>
        /// <param name="fecha">La fecha por la que buscar en la BBDD una temperatura.</param>
        /// <returns>Un <see cref="ClsTemperaturaConNombreInvernadero"/> relleno con valores que encuentre en la BBDD. Si no
        /// lo encuentra, puede estar nulo o vacío.</returns>
        public static ClsTemperaturaConNombreInvernadero BuscarTemperaturaConNombrePorFecha(int idInvernadero, DateTime fecha)
        {
            return ManejadoraDTO.BuscarTemperaturaConNombrePorFecha(idInvernadero, fecha.Date);
        }
    }
}
