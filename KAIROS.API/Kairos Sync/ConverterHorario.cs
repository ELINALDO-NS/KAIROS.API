using API.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Kairos_Sync
{
    public class ConverterHorario : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Horarios[] horarios && horarios.Length > 0)
            {
                var Horario = horarios.FirstOrDefault(x=> x.Fim == "31/12/9999 23:59:59") ;
                return Horario?.Horario?.Descricao ?? "";
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
