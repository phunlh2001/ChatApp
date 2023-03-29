using ChatApp.Extensions;
using ChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty, Required(ErrorMessage = "Confirm password must be not empty")]
        public string ConfirmPassword { get; set; }
        [BindProperty] public Account Account { get; set; }

        public async Task<IActionResult> OnPostRegisterAsync()
        {
            if (ModelState.IsValid)
            {
                var emailExist = await _context.Accounts.FirstOrDefaultAsync(a => a.Username == Account.Username);
                if (emailExist != null)
                {
                    ViewData["err"] = "Email already exists";
                }
                else if (Account.Password != ConfirmPassword)
                {
                    ViewData["err"] = "Password invalid";
                }
                else
                {
                    _context.Accounts.Add(Account);
                    await _context.SaveChangesAsync();
                    ViewData["success"] = "Register successfull";
                }
            }
            return Page();
        }

        public IActionResult OnPostLogin(string username, string password)
        {
            var user = _context.Accounts.FirstOrDefault(a => a.Username == username);
            if (user != null && user.Password == password)
            {
                HttpContext.Session.SetObject("user", user);
                HttpContext.Session.SetString("username", username);
                return Redirect("/");
            }
            return Page();
        }
    }
}
