using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.BLL.Interfaces
{
    public interface ICurrency
    {
        decimal GetRate(string From, string To);

    }
}
