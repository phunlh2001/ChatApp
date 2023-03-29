using ChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var isLogin = HttpContext.Session.GetString("user") != null;
            if (!isLogin)
            {
                return Redirect("/login");
            }
            else
            {
                Account = await _context.Accounts.ToListAsync();
            }

            return Page();
        }
    }
}
