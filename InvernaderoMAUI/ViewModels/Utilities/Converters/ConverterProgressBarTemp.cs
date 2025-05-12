using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvernaderoMAUI.ViewModels.Utilities.Converters
{
    public class ConverterProgressBarTemp : IValueConverter
    {

        /// <summary>
        /// Función que recibe un valor entre -10 y 50 y devuelve entre 0 y 1.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            double temp = 0.0;

            if(value != null)
            {
                temp = (double)value / 50.0;
            }

            return temp;
        }

        /// <summary>
        /// Retornamos el mismo valor porque no necesitamos ninguna conversión de vuelta.
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
