using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barta_Timea_Proiect.Store
{
    public class Wine
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Wine Name")]
        public string Name { get; set; }
        public decimal Alcohol { get; set; }

        [Range(1, 300)]

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
        
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public ICollection<WineAssortment> WineAssortments { get; set; }
    }
}
