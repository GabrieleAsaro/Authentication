using System.ComponentModel.DataAnnotations;

namespace Authentication.Model
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
