using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barta_Timea_Proiect.Store
{
    public class WineData
    {
        public IEnumerable<Wine> Wines { get; set; }
        public IEnumerable<Assortment> Assortments { get; set; }
        public IEnumerable<WineAssortment> WineAssortments { get; set; }
    }
}
