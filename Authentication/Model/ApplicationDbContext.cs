using Authentication.Model;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Model
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<User> User { get; set; }

	}
}
