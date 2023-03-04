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
    public class IndexModel : PageModel
    {
        private readonly ChristarIsAwesome.Data.ApplicationDbContext _context;

        public IndexModel(ChristarIsAwesome.Data.ApplicationDbContext context) => _context = context;

        public IList<AwesomePost> AwesomePost { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AwesomePost != null)
            {
                AwesomePost = await _context.AwesomePost.ToListAsync();
            }
        }
    }
}
