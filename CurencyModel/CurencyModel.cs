using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CurencyModel
{
    [DataContract]
    public class Curency
    {
        [DataMember] public string Key { get; set; }
        [DataMember] public double Rate { get; set; }
        [DataMember] public double Change { get; set; }
        [DataMember] public int Unit { get; set; }

    }
    [CollectionDataContract]
    public class CurencyList : List<Curency> 
    {
        public CurencyList() { }
        public CurencyList (IEnumerable<Curency> list) { }
    }

}
