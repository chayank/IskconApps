using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IskconKBCServer.Data;
using IskconKBCServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IskconKBCServer
{
    public class FamilyMemberModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<FamilyMemberModel> _logger;
        private IdentityUser user;
        public FamilyMemberModel(ApplicationDbContext context,
             UserManager<IdentityUser> userManager,
            ILogger<FamilyMemberModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }
        public async Task OnGetAsync()
        {
            user = await _userManager.GetUserAsync(User);
            FamilyDetails = await _context.Devotees.Where(x => x.UserId == user.Id).ToListAsync();
            ViewData["UserId"] = user.Id;
        }

        public IList<Devotee> FamilyDetails { get; set; }

        [BindProperty]
        public Devotee Devotee { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                user = await _userManager.GetUserAsync(User);
                FamilyDetails = await _context.Devotees.Where(x => x.UserId == user.Id).ToListAsync();
                ViewData["UserId"] = user.Id;
                return Page();
            }
            _context.Devotees.Add(Devotee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./FamilyMember");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var member = await _context.Devotees.FindAsync(id);

            if(member!=null)
            {
                _context.Devotees.Remove(member);
                await _context.SaveChangesAsync();
            }
            user = await _userManager.GetUserAsync(User);
            FamilyDetails = await _context.Devotees.Where(x => x.UserId == user.Id).ToListAsync();
            ViewData["UserId"] = user.Id;
            return Page();
        }

    }
}