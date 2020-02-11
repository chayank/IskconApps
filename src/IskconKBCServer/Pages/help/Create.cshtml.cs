using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IskconKBCServer.Data;
using IskconKBCServer.Models;

namespace IskconKBCServer
{
    public class CreateModel : PageModel
    {
        private readonly IskconKBCServer.Data.ApplicationDbContext _context;

        public CreateModel(IskconKBCServer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DevoteeId"] = new SelectList(_context.Devotees, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public DevoteeDetail DevoteeDetail { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DevoteeDetails.Add(DevoteeDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
