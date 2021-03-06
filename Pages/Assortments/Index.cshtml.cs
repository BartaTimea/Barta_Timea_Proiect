﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext _context;

        public IndexModel(Barta_Timea_Proiect.Data.Barta_Timea_ProiectContext context)
        {
            _context = context;
        }

        public IList<Assortment> Assortment { get;set; }

        public async Task OnGetAsync()
        {
            Assortment = await _context.Assortment.ToListAsync();
        }
    }
}
