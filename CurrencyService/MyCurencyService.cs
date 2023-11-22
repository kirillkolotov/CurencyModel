using CurencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CurencyBL;

namespace CurrencyService
{
    public class MyCurrencyService : ICurrencyService
    {
        public CurencyList GetAllCurrencies()
        {
            CurencyManager manager = new CurencyManager();
            return manager.GetCurrencyList();
        }
        public double Convert(Curency source, Curency dest, double amount)
        {
            CurencyManager manager = new CurencyManager();
            return manager.Convert(source, dest, amount);
        }
    }
}
