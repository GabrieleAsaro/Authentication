using System.Threading.Tasks;
using Authentication.Model;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public LoginModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public User User { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            User.Password = Protection.Sha256(User.Password);

            var user = await _db.User.FirstOrDefaultAsync(u => u.Username == User.Username && u.Password == User.Password);

            if (user == null) return Page();
            
            return RedirectToPage("LoginSuccess", new { userName = user.Username });
        }

    }
}
