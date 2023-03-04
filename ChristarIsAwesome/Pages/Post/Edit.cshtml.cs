using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChristarIsAwesome.Data;
using ChristarIsAwesome.Models;

namespace ChristarIsAwesome.Pages.Post
{
    public class EditModel : PageModel
    {
        private readonly ChristarIsAwesome.Data.ApplicationDbContext _context;

        public EditModel(ChristarIsAwesome.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AwesomePost AwesomePost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AwesomePost == null)
            {
                return NotFound();
            }

            var awesomepost =  await _context.AwesomePost.FirstOrDefaultAsync(m => m.Id == id);
            if (awesomepost == null)
            {
                return NotFound();
            }
            AwesomePost = awesomepost;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AwesomePost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AwesomePostExists(AwesomePost.Id))
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

        private bool AwesomePostExists(int id)
        {
          return (_context.AwesomePost?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
