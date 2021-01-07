using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Barta_Timea_Proiect.Data;
using Barta_Timea_Proiect.Store;

namespace Barta_Timea_Proiect.Pages.Assortments
{
    public class EditModel : PageModel
    {
        private readonly Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext _context;

        public EditModel(Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Assortment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssortmentExists(Assortment.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AssortmentExists(int id)
        {
            return _context.Assortment.Any(e => e.ID == id);
        }
    }
}
