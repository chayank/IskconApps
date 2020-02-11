using IskconKBCServer.Data;
using IskconKBCServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IskconKBCServer
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public DetailsModel(ApplicationDbContext context,
             UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            Devotees = await _context.Devotees.Where(x => x.UserId == user.Id).ToListAsync();
            ViewData["DevoteeId"] = id;
            if (id == null)
            {
                id= Devotees.First(x => x.RelationshipWithUser == Common.Relation.Self).Id;
                ViewData["DevoteeId"] = id;
            }
            var detail = await _context.DevoteeDetails.FirstOrDefaultAsync(x => x.DevoteeId == id);
            if(detail!=null)
            {
                DevoteeDetail = detail;
            }
            return Page();
        }

        [BindProperty]
        public DevoteeDetail DevoteeDetail { get; set; }
        [BindProperty]
        public IEnumerable<Devotee> Devotees { get; set; }

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

            return await OnGetAsync(DevoteeDetail.DevoteeId);

        }

        public async Task<IActionResult> OnPostUpdateAsync()
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

            return await OnGetAsync(DevoteeDetail.DevoteeId);

        }

        private bool DevoteeDetailExists(int id)
        {
            return _context.DevoteeDetails.Any(e => e.Id == id);
        }
    }
}