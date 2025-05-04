using DAL;
using ENT;

namespace BL
{
    public class ListadoInvernaderosBL
    {
        /// <summary>
        /// Función que se encarga de realizar una conexión con la base de datos y devuelve un <see cref="List{ClsInvernadero}"/> relleno de invernaderos, para luego cerrar dicha conexión.
        /// Pre: Nada. Post: Devuelve un <see cref="List{ClsInvernadero}"/> con objetos de tipo <see cref="ClsInvernadero"/>.
        /// </summary>
        /// <returns>Un <see cref="List{ClsInvernadero}"/> relleno con objetos de tipo <see cref="ClsInvernadero"/>. Estará vacío si en la BBDD no hay datos.</returns>
        public static List<ClsInvernadero> ObtenerListadoInvernaderos()
        {
            return ListadoInvernaderosDAL.ObtenerListadoInvernaderos();
        }
    }
}
