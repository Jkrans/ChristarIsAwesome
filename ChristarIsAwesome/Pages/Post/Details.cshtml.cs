using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChristarIsAwesome.Data;
using ChristarIsAwesome.Models;

namespace ChristarIsAwesome.Pages.Post
{
    public class DetailsModel : PageModel
    {
        private readonly ChristarIsAwesome.Data.ApplicationDbContext _context;

        public DetailsModel(ChristarIsAwesome.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public AwesomePost AwesomePost { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AwesomePost == null)
            {
                return NotFound();
            }

            var awesomepost = await _context.AwesomePost.FirstOrDefaultAsync(m => m.Id == id);
            if (awesomepost == null)
            {
                return NotFound();
            }
            else 
            {
                AwesomePost = awesomepost;
            }
            return Page();
        }
    }
}
