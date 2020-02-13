using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IskconKBCServer.Common;
using IskconKBCServer.Data;
using IskconKBCServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IskconKBCServer
{
    public class LanguageModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public LanguageModel(ApplicationDbContext context,
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

            var detail = await _context.DevoteeLanguageProficiencies.FirstOrDefaultAsync(x => x.DevoteeId == id);
            if (detail != null)
            {
                SetAllLists(detail);
                DevoteeLanguageProficiency = detail;
            }

            return Page();
        }

        public void SetAllLists(DevoteeLanguageProficiency dlp)
        {
            var languages = Enum.GetNames(typeof(Language));
            var count = languages.Length;
            Speaks = new List<bool>(new bool[count]);
            Reads = new List<bool>(new bool[count]);
            Writes = new List<bool>(new bool[count]);
            Translatables = new List<bool>(new bool[count]);

            List<int> readList = dlp.Read.Length > 1 ? dlp.Read.Split(',').Select(Int32.Parse).ToList() : (dlp.Read == string.Empty ? null : new List<int> { Int32.Parse(dlp.Read) });
            List<int> speakList = dlp.Speak.Length > 1 ? dlp.Speak.Split(',').Select(Int32.Parse).ToList() : (dlp.Speak == string.Empty ? null : new List<int> { Int32.Parse(dlp.Speak) });
            List<int> writeList = dlp.Write.Length > 1 ? dlp.Write.Split(',').Select(Int32.Parse).ToList() : (dlp.Write == string.Empty ? null : new List<int> { Int32.Parse(dlp.Write) });
            List<int> translateList = dlp.TranslatableFromEnglish.Length > 1 ? dlp.TranslatableFromEnglish.Split(',').Select(Int32.Parse).ToList() : (dlp.TranslatableFromEnglish == string.Empty ? null : new List<int> { Int32.Parse(dlp.TranslatableFromEnglish) });

            if (speakList != null) SetFlags(Speaks, speakList);
            if (readList != null) SetFlags(Reads, readList);
            if (writeList != null) SetFlags(Writes, writeList);
            if (translateList != null) SetFlags(Translatables, translateList);

            MotherTongue = dlp.MotherTongue;
        }

        public void SetFlags(List<bool> assignlist, List<int> list)
        {
            foreach (var x in list)
            {
                assignlist[x] = true;
            }
        }

        public DevoteeLanguageProficiency DevoteeLanguageProficiency { get; set; }
        [BindProperty]
        public List<Devotee> Devotees { get; set; }
        [BindProperty]
        public List<bool> Speaks { get; set; }
        [BindProperty]
        public List<bool> Reads { get; set; }
        [BindProperty]
        public List<bool> Writes { get; set; }
        [BindProperty]
        public List<bool> Translatables { get; set; }
        [BindProperty]
        public Language MotherTongue { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var languages = Enum.GetNames(typeof(Language));
            var count = languages.Length;
            List<string> speak = new List<string>();
            List<string> read = new List<string>();
            List<string> write = new List<string>();
            List<string> translate = new List<string>();
            for (var i = 0; i < count; i++)
            {
                var x = i.ToString();
                if (Speaks[i])
                    speak.Add(x);
                if (Reads[i])
                    read.Add(x);
                if (Writes[i])
                    write.Add(x);
                if (Translatables[i])
                    translate.Add(x);
            }
            DevoteeLanguageProficiency devoteeLanguageProficiency = new DevoteeLanguageProficiency();
            DevoteeLanguageProficiency = devoteeLanguageProficiency;
            DevoteeLanguageProficiency.DevoteeId = id;
            DevoteeLanguageProficiency.Speak = string.Join(',', speak);
            DevoteeLanguageProficiency.Read = string.Join(',', read);
            DevoteeLanguageProficiency.Write = string.Join(',', write);
            DevoteeLanguageProficiency.TranslatableFromEnglish = string.Join(',', translate);
            DevoteeLanguageProficiency.MotherTongue = MotherTongue;

            _context.DevoteeLanguageProficiencies.Add(DevoteeLanguageProficiency);
            await _context.SaveChangesAsync();

            return await OnGetAsync(DevoteeLanguageProficiency.DevoteeId);

        }

        public async Task<IActionResult> OnPostUpdateAsync(int id)
        {
            var devoteeToUpdate = await _context.DevoteeLanguageProficiencies.FirstOrDefaultAsync(x=>x.DevoteeId==id);

            if (devoteeToUpdate == null)
            {
                return NotFound();
            }
            //
            var languages = Enum.GetNames(typeof(Language));
            var count = languages.Length;
            List<string> speak = new List<string>();
            List<string> read = new List<string>();
            List<string> write = new List<string>();
            List<string> translate = new List<string>();
            for (var i = 0; i < count; i++)
            {
                var x = i.ToString();
                if (Speaks[i])
                    speak.Add(x);
                if (Reads[i])
                    read.Add(x);
                if (Writes[i])
                    write.Add(x);
                if (Translatables[i])
                    translate.Add(x);
            }
            DevoteeLanguageProficiency devoteeLanguageProficiency = new DevoteeLanguageProficiency();
            DevoteeLanguageProficiency = devoteeLanguageProficiency;
            DevoteeLanguageProficiency.DevoteeId = id;
            DevoteeLanguageProficiency.Speak = string.Join(',', speak);
            DevoteeLanguageProficiency.Read = string.Join(',', read);
            DevoteeLanguageProficiency.Write = string.Join(',', write);
            DevoteeLanguageProficiency.TranslatableFromEnglish = string.Join(',', translate);
            DevoteeLanguageProficiency.MotherTongue = MotherTongue;
            //
            if (await TryUpdateModelAsync<DevoteeLanguageProficiency>(
                devoteeToUpdate,
                "devotee", s => s.Speak, s => s.Read, s => s.Write, s => s.MotherTongue,
                s => s.TranslatableFromEnglish))
            {
                await _context.SaveChangesAsync();
            }

            return await OnGetAsync(DevoteeLanguageProficiency.DevoteeId);

        }
    }
}