using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ItLabs.Converters
{
    public class ParentActualWidthToMinWidthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is double parentActualWidth && values[1] is Window window)
            {
                // Устанавливаем минимальную ширину и высоту на основе ширины и высоты окна
                if (parentActualWidth <= 300)
                {
                    window.MinWidth = 800;
                }
                else
                {
                    window.MinWidth = 800; // Значение по умолчанию или другое на ваш выбор
                }

                // Пример установки минимальной высоты
                window.MinHeight = 600; // Значение по умолчанию или другое на ваш выбор
            }

            return Binding.DoNothing;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
