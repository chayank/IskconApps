using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IskconKBCServer.Data;
using IskconKBCServer.Models;

namespace IskconKBCServer
{
    public class EditModel : PageModel
    {
        private readonly IskconKBCServer.Data.ApplicationDbContext _context;

        public EditModel(IskconKBCServer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DevoteeDetail DevoteeDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DevoteeDetail = await _context.DevoteeDetails
                .Include(d => d.Devotee).FirstOrDefaultAsync(m => m.Id == id);

            if (DevoteeDetail == null)
            {
                return NotFound();
            }
           ViewData["DevoteeId"] = new SelectList(_context.Devotees, "Id", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DevoteeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevoteeDetailExists(DevoteeDetail.Id))
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

        private bool DevoteeDetailExists(int id)
        {
            return _context.DevoteeDetails.Any(e => e.Id == id);
        }
    }
}
