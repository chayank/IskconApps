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
    public class IndexModel : PageModel
    {
        private readonly IskconKBCServer.Data.ApplicationDbContext _context;

        public IndexModel(IskconKBCServer.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DevoteeDetail> DevoteeDetail { get;set; }

        public async Task OnGetAsync()
        {
            DevoteeDetail = await _context.DevoteeDetails
                .Include(d => d.Devotee).ToListAsync();
        }
    }
}
