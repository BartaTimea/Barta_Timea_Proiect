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

namespace Barta_Timea_Proiect.Pages.Wines
{
    public class EditModel : WineAssortmentsPageModel
    {
        private readonly Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext _context;

        public EditModel(Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Wine Wine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wine = await _context.Wine
                .Include(b => b.Brand)
                .Include(b => b.WineAssortments).ThenInclude(b => b.Assortment)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Wine == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData 

            PopulateAssignedAssortmentData(_context, Wine);

            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "BrandName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedAssortments)
        {
            if (id == null)
            {
                return NotFound();
            }
            var wineToUpdate = await _context.Wine
                .Include(i => i.Brand)
                .Include(i => i.WineAssortments)
                .ThenInclude(i => i.Assortment)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (wineToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Wine>(wineToUpdate, "Wine", i => i.Name, i => i.Alcohol, i => i.Price, i => i.ProductionDate, i => i.Brand))
            {
                UpdateWineAssortments(_context, selectedAssortments, wineToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care este editata 
            UpdateWineAssortments(_context, selectedAssortments, wineToUpdate);
            PopulateAssignedAssortmentData(_context, wineToUpdate);
            return Page();

        }

        private bool WineExists(int id)
        {
            return _context.Wine.Any(e => e.ID == id);
        }
    }
}
