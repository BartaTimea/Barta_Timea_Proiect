using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Barta_Timea_Proiect.Data;
using Barta_Timea_Proiect.Store;

namespace Barta_Timea_Proiect.Pages.Wines
{
    public class IndexModel : PageModel
    {
        private readonly Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext _context;

        public IndexModel(Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext context)
        {
            _context = context;
        }

        public IList<Wine> Wine { get;set; }
        public WineData WineD { get; set; }
        public int WineID { get; set; }
        public int AssortmentID { get; set; }
        public async Task OnGetAsync(int? id, int? assortmentID)
        {
            WineD = new WineData();

            WineD.Wines = await _context.Wine
            .Include(b => b.Brand)
            .Include(b => b.WineAssortments)
            .ThenInclude(b => b.Assortment)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                WineID = id.Value;
                Wine wine = WineD.Wines.Where(i => i.ID == id.Value).Single();
                WineD.Assortments = wine.WineAssortments.Select(s => s.Assortment);
            }
        }
    }
}
