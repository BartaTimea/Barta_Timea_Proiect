using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Barta_Timea_Proiect.Data;
using Barta_Timea_Proiect.Store;

namespace Barta_Timea_Proiect.Pages.Assortments
{
    public class DetailsModel : PageModel
    {
        private readonly Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext _context;

        public DetailsModel(Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext context)
        {
            _context = context;
        }

        public Assortment Assortment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assortment = await _context.Assortment.FirstOrDefaultAsync(m => m.ID == id);

            if (Assortment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
