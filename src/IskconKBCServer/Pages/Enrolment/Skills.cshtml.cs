using System;
using System.Collections.Generic;
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

namespace IskconKBCServer
{
    public class SkillsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public SkillsModel(ApplicationDbContext context,
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
                id = Devotees.First(x => x.RelationshipWithUser == Relation.Self).Id;
                ViewData["DevoteeId"] = id;
            }

            var detail = await _context.DevoteeSkills.FirstOrDefaultAsync(x => x.DevoteeId == id);
            if (detail != null)
            {
                SetAllLists(detail);
                DevoteeSkill = detail;
            }

            return Page();
        }

        public void SetAllLists(DevoteeSkill ds)
        {
            var skills = Enum.GetNames(typeof(Skill));
            var count = skills.Length;

            Learning = new List<bool>(new bool[count]);
            Teaching = new List<bool>(new bool[count]);
            UsingInYatra = new List<bool>(new bool[count]);
            HaveTheSkills = new List<bool>(new bool[count]);

            List<int> learningList = ds.Learning.Length > 1 ? ds.Learning.Split(',').Select(Int32.Parse).ToList() : (ds.Learning == string.Empty ? null : new List<int> { Int32.Parse(ds.Learning) });
            List<int> teachingList = ds.Teaching.Length > 1 ? ds.Teaching.Split(',').Select(Int32.Parse).ToList() : (ds.Teaching == string.Empty ? null : new List<int> { Int32.Parse(ds.Teaching) });
            List<int> usingInYatraList = ds.UsingInYatra.Length > 1 ? ds.UsingInYatra.Split(',').Select(Int32.Parse).ToList() : (ds.UsingInYatra == string.Empty ? null : new List<int> { Int32.Parse(ds.UsingInYatra) });
            List<int> haveTheSkillsList = ds.HaveTheSkills.Length > 1 ? ds.HaveTheSkills.Split(',').Select(Int32.Parse).ToList() : (ds.HaveTheSkills == string.Empty ? null : new List<int> { Int32.Parse(ds.HaveTheSkills) });

            if(learningList!=null)SetFlags(Learning, learningList);
            if(teachingList!=null) SetFlags(Teaching, teachingList);
            if (usingInYatraList != null) SetFlags(UsingInYatra, usingInYatraList);
            if (haveTheSkillsList != null) SetFlags(HaveTheSkills, haveTheSkillsList);

            SpecialSkills = ds.SpecialSkills;
        }

        public void SetFlags(List<bool> assignlist, List<int> list)
        {
            foreach (var x in list)
            {
                assignlist[x] = true;
            }
        }

        public DevoteeSkill DevoteeSkill { get; set; }
        [BindProperty]
        public List<Devotee> Devotees { get; set; }
        [BindProperty]
        public List<bool> Learning { get; set; }
        [BindProperty]
        public List<bool> Teaching { get; set; }
        [BindProperty]  
        public List<bool> UsingInYatra { get; set; }
        [BindProperty]
        public List<bool> HaveTheSkills { get; set; }
        [BindProperty]
        public string SpecialSkills { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var skills = Enum.GetNames(typeof(Skill));
            var count = skills.Length;
            List<string> learning = new List<string>();
            List<string> teaching = new List<string>();
            List<string> usingInYatra = new List<string>();
            List<string> haveTheSkills = new List<string>();
            for (var i = 0; i < count; i++)
            {
                var x = i.ToString();
                if (Learning[i])
                    learning.Add(x);
                if (Teaching[i])
                    teaching.Add(x);
                if (UsingInYatra[i])
                    usingInYatra.Add(x);
                if (HaveTheSkills[i])
                    haveTheSkills.Add(x);
            }
            DevoteeSkill devoteeSkill = new DevoteeSkill();
            DevoteeSkill = devoteeSkill;
            DevoteeSkill.DevoteeId = id;
            DevoteeSkill.Learning = string.Join(',',learning);
            DevoteeSkill.Teaching = string.Join(',', teaching); ;
            DevoteeSkill.UsingInYatra = string.Join(',', usingInYatra); ;
            DevoteeSkill.HaveTheSkills = string.Join(',', haveTheSkills); ;
            DevoteeSkill.SpecialSkills = SpecialSkills;

            _context.DevoteeSkills.Add(DevoteeSkill);
            await _context.SaveChangesAsync();

            return await OnGetAsync(DevoteeSkill.DevoteeId);

        }

        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            var devoteeToUpdate = await _context.DevoteeSkills.FirstOrDefaultAsync(x => x.DevoteeId == id);

            if (devoteeToUpdate == null)
            {
                return NotFound();
            }
            //
            var skills = Enum.GetNames(typeof(Skill));
            var count = skills.Length;
            List<string> learning = new List<string>();
            List<string> teaching = new List<string>();
            List<string> usingInYatra = new List<string>();
            List<string> haveTheSkills = new List<string>();
            for (var i = 0; i < count; i++)
            {
                var x = i.ToString();
                if (Learning[i])
                    learning.Add(x);
                if (Teaching[i])
                    teaching.Add(x);
                if (UsingInYatra[i])
                    usingInYatra.Add(x);
                if (HaveTheSkills[i])
                    haveTheSkills.Add(x);
            }
            DevoteeSkill devoteeSkill = new DevoteeSkill();
            DevoteeSkill = devoteeSkill;
            DevoteeSkill.DevoteeId = id;
            DevoteeSkill.Learning = string.Join(',', learning);
            DevoteeSkill.Teaching = string.Join(',', teaching);
            DevoteeSkill.UsingInYatra = string.Join(',', usingInYatra);
            DevoteeSkill.HaveTheSkills = string.Join(',', haveTheSkills);
            DevoteeSkill.SpecialSkills = SpecialSkills;
            //
            if (await TryUpdateModelAsync<DevoteeSkill>(
                devoteeToUpdate,
                "devotee",
                s=>s.DevoteeId,
                s => s.Learning, s => s.Teaching,
                s => s.UsingInYatra, s => s.HaveTheSkills,
                s => s.SpecialSkills))
            {
                await _context.SaveChangesAsync();
            }

            return await OnGetAsync(DevoteeSkill.DevoteeId);

        }
    }
}