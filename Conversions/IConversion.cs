using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterApp.Conversions
{
    public interface IConversion
    {
        int Id { get; }
        string FromUnit { get; }
        string ToUnit { get; }
        double Convert(double value);
    }
}
