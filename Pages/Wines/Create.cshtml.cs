using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Barta_Timea_Proiect.Data;
using Barta_Timea_Proiect.Store;

namespace Barta_Timea_Proiect.Pages.Wines
{
    public class CreateModel : WineAssortmentsPageModel
    {
        private readonly Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext _context;

        public CreateModel(Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "BrandName");
            var wine = new Wine();
            wine.WineAssortments = new List<WineAssortment>();
            PopulateAssignedAssortmentData(_context, wine);
            return Page();
        }

        [BindProperty]
        public Wine Wine { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync(string[] selectedAssortments)
        {
            var newWine = new Wine();
            if (selectedAssortments != null)
            {
                newWine.WineAssortments = new List<WineAssortment>();
                foreach (var ass in selectedAssortments)
                {
                    var assToAdd = new WineAssortment
                    {
                        AssortmentID = int.Parse(ass)
                    };
                    newWine.WineAssortments.Add(assToAdd);
                }
            }
            if (await TryUpdateModelAsync<Wine>(newWine, "Wine", i => i.Name, i => i.Alcohol, i => i.Price, i => i.ProductionDate, i => i.BrandID))
            {
                _context.Wine.Add(newWine);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedAssortmentData(_context, newWine);
            return Page();
        }
    }
}
