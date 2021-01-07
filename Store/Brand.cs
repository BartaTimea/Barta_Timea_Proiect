using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barta_Timea_Proiect.Store
{
    public class Brand
    {
        public int ID { get; set; }
        public string BrandName { get; set; }
        public ICollection<Wine> Wines { get; set; }
    }
}
