using System.Threading.Tasks;
using Authentication.Model;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Pages.Auth
{
    public class LoginSuccess : PageModel
    {

        private readonly ApplicationDbContext _db;

        public LoginSuccess(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task OnGet(string userName)
        {
            User = await _db.User.FirstOrDefaultAsync(u => u.Username == userName);
        }
    }
}