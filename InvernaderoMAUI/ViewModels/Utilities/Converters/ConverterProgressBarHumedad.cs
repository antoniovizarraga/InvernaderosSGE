using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvernaderoMAUI.ViewModels.Utilities.Converters
{
    public class ConverterProgressBarHumedad : IValueConverter
    {

        /// <summary>
        /// Función que recibe una humedad entre 0 y 100 y devuelve entre un 0 y 1
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {

            double humedad = 0.0;

            if (value != null)
            {
                humedad = (double)value / 100.0;
            }

            return humedad;

        }

        /// <summary>
        /// Esta función no hace falta porque no tenemos que convertir el valor de vuelta
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
