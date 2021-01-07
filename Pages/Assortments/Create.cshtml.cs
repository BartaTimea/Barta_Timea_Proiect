using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Barta_Timea_Proiect.Data;
using Barta_Timea_Proiect.Store;

namespace Barta_Timea_Proiect.Pages.Assortments
{
    public class CreateModel : PageModel
    {
        private readonly Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext _context;

        public CreateModel(Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Assortment Assortment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Assortment.Add(Assortment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
