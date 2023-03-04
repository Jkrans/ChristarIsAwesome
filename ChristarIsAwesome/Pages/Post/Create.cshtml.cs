using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChristarIsAwesome.Data;
using ChristarIsAwesome.Models;

namespace ChristarIsAwesome.Pages.Post
{
    public class CreateModel : PageModel
    {
        private readonly ChristarIsAwesome.Data.ApplicationDbContext _context;

        public CreateModel(ChristarIsAwesome.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AwesomePost AwesomePost { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AwesomePost == null || AwesomePost == null)
            {
                return Page();
            }

            _context.AwesomePost.Add(AwesomePost);
            await _context.SaveChangesAsync();

            return RedirectToPage("./SubmissionThanks");
        }
    }
}
