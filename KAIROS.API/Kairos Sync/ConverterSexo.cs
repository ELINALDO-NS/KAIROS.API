using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Kairos_Sync
{
    public class ConverterSexo:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int sexo)
            {
                return sexo switch
                {
                    0 => "Masculino",
                   1 => "Feminino",
                    _ => "Outro"
                };
            }
            return "Outro";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    
    }
}
