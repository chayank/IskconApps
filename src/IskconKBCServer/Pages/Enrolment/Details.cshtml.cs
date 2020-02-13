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

        public async Task<IActionResult> OnPostUpdateAsync(int? id)
        {
            var devoteeToUpdate = await _context.DevoteeDetails.FirstOrDefaultAsync(x => x.DevoteeId == id);

            if (devoteeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<DevoteeDetail>(
                devoteeToUpdate,
                "devotee", s => s.InitiatedName, s => s.Sex, s => s.Dob, s=>s.Address, 
                s => s.Profession, s => s.MobileNo, s => s.WhatsappMobileNo,
                s => s.EmergencyContactName, s => s.EmergencyContactMobileNo))
            {
                await _context.SaveChangesAsync();
            }

            return await OnGetAsync(DevoteeDetail.DevoteeId);

        }
    }
}