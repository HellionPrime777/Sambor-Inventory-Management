using System;
using System.Globalization;
using System.Windows.Data;

namespace Inventory_Management.Model
{
    public class DecimalToPositiveConverter : IValueConverter
    {
        /// <summary>
        /// Клас DecimalToPositiveConverter дозволяє перетворювати десяткове число на булеве значення, вказуючи, чи є число додатним. 
        /// Це корисно при використанні прив'язки даних із виглядом, де потрібно виконати умовне форматування або обробку залежно від знаку числа.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal)
                return (0 <= (decimal)value);
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                    return 1;
                else
                    return -1;
            }
            return 0;
        }
    }
}
