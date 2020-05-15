using System.Threading.Tasks;
using Authentication.Model;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Authentication.Pages.Auth
{
    public class RegisterModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public RegisterModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            User.Password = Protection.Sha256(User.Password);
            await _db.User.AddAsync(User);
            await _db.SaveChangesAsync();
            return RedirectToPage("RegisterSuccess");
        }

    }
}