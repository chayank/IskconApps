using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IskconKBCServer.Data;
using IskconKBCServer.Models;

namespace IskconKBCServer
{
    public class DeleteModel : PageModel
    {
        private readonly IskconKBCServer.Data.ApplicationDbContext _context;

        public DeleteModel(IskconKBCServer.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DevoteeDetail = await _context.DevoteeDetails.FindAsync(id);

            if (DevoteeDetail != null)
            {
                _context.DevoteeDetails.Remove(DevoteeDetail);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
