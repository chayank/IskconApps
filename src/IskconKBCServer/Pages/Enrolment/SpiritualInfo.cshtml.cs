using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IskconKBCServer.Common;
using IskconKBCServer.Common.Enums;
using IskconKBCServer.Data;
using IskconKBCServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace IskconKBCServer
{
    public class SpiritualInfoModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public SpiritualInfoModel(ApplicationDbContext context,
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
                id = Devotees.First(x => x.RelationshipWithUser == Common.Relation.Self).Id;
                ViewData["DevoteeId"] = id;
            }
            

            var detail = await _context.DevoteeSpiritualInformations.FirstOrDefaultAsync(x => x.DevoteeId == id);
            if (detail != null)
            {
                SetAllLists(detail);
                DevoteeSpiritualInformation = detail;
            }
            return Page();
        }

        public void SetAllLists(DevoteeSpiritualInformation ds)
        {
            var prgTypes = Enum.GetNames(typeof(ProgramType));
            var count = prgTypes.Length;

            AttendingOrTeaching = new List<SpiritualInfoCustomOption>(new SpiritualInfoCustomOption[count]);
            Achieved = new List<bool>(new bool[count]);

            List<int> attendingList = ds.Attending.Length > 1 ? ds.Attending.Split(',').Select(Int32.Parse).ToList() : (ds.Attending == string.Empty ? null : new List<int> { Int32.Parse(ds.Attending) });
            List<int> teachingList = ds.Teaching.Length > 1 ? ds.Teaching.Split(',').Select(Int32.Parse).ToList() : (ds.Teaching == string.Empty ? null : new List<int> { Int32.Parse(ds.Teaching) });


            List<int> achievedList = ds.ShikshaLevel.Length > 1 ? ds.ShikshaLevel.Split(',').Select(Int32.Parse).ToList() : (ds.ShikshaLevel == string.Empty ? null : new List<int> { Int32.Parse(ds.ShikshaLevel) });

            if (attendingList != null) SetFlags(attendingList, SpiritualInfoCustomOption.Attending);
            if (teachingList != null) SetFlags(teachingList, SpiritualInfoCustomOption.Teaching);
            if (achievedList != null) SetFlags(achievedList);

        }

        public void SetFlags(List<int> list, SpiritualInfoCustomOption spiritualInfoCustomOption)
        {
            foreach (var x in list)
            {
                AttendingOrTeaching[x] = spiritualInfoCustomOption;
            }
        }

        public void SetFlags(List<int> list)
        {
            foreach (var x in list)
            {
                Achieved[x] = true ;
            }
        }



        [BindProperty]
        public DevoteeSpiritualInformation DevoteeSpiritualInformation { get; set; }
        [BindProperty]
        public List<Devotee> Devotees { get; set; }
        [BindProperty]
        public List<SpiritualInfoCustomOption> AttendingOrTeaching { get; set; }
      //  [BindProperty]
        //public List<bool> Teaching { get; set; }
        [BindProperty]
        public List<bool> Achieved { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                ViewData["DevoteeId"] = id;
                return Page();
            }
            SetProgramStats();
            SetShikshaLvlInfo();
            DevoteeSpiritualInformation.DevoteeId = id;
            _context.DevoteeSpiritualInformations.Add(DevoteeSpiritualInformation);
            await _context.SaveChangesAsync();

            return await OnGetAsync(DevoteeSpiritualInformation.DevoteeId);

        }

        private void SetProgramStats()
        {
            var prtypes = Enum.GetNames(typeof(ProgramType));
            var count = prtypes.Length;
            List<string> attendingList = new List<string>();
            List<string> teachingList = new List<string>();
            for (var i=0;i< count; i++)
            {
                var x = i.ToString();
                switch (AttendingOrTeaching[i])
                {
                    case SpiritualInfoCustomOption.Attending:
                        attendingList.Add(x);
                        break;
                    case SpiritualInfoCustomOption.Teaching:
                        teachingList.Add(x);
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }

            }

            DevoteeSpiritualInformation.Attending= string.Join(',', attendingList);
            DevoteeSpiritualInformation.Teaching = string.Join(',', teachingList);

        }
        private void SetShikshaLvlInfo()
        {
            var prtypes = Enum.GetNames(typeof(ShikshaLevel));
            var count = prtypes.Length;
            List<string> shikshaLvlList = new List<string>();
            for (var i = 0; i < count; i++)
            {
                var x = i.ToString();
                if (Achieved[i])
                    shikshaLvlList.Add(x);
            }

            DevoteeSpiritualInformation.ShikshaLevel = string.Join(',', shikshaLvlList);
        }

        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                ViewData["DevoteeId"] = id;
                return Page();
            }
            var devoteeToUpdate = await _context.DevoteeSpiritualInformations.FirstOrDefaultAsync(x => x.DevoteeId == id);

            if (devoteeToUpdate == null)
            {
                return NotFound();
            }
            SetProgramStats();
            SetShikshaLvlInfo();
            DevoteeSpiritualInformation.DevoteeId = id;
            if (await TryUpdateModelAsync<DevoteeSpiritualInformation>(
                devoteeToUpdate,
                "devotee", s => s.IsAssociatedToBv, s => s.BvName, s => s.SectorName, s => s.CircleName,
                s => s.ResponsibiltyType, s => s.Attending,s => s.Teaching,s => s.ShikshaLevel))
            {
                await _context.SaveChangesAsync();
            }

            return await OnGetAsync(DevoteeSpiritualInformation.DevoteeId);

        }
    }
}