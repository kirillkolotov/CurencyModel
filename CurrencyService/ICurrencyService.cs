using CurencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyService
{
    [ServiceContract]
    public interface ICurrencyService
    {
        [OperationContract]
        CurencyList GetAllCurrencies();
        [OperationContract]
        double Convert(Curency source, Curency dest, double amount);
    }
}
