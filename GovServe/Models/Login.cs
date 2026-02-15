using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GovServe.Models
{
	public class Login
	{
		[Key]
		public int Id { get; set; }
		[Required, EmailAddress, MaxLength(100)]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		// ConfirmPassword is not stored in DB, only used for validation
		[NotMapped]
		public string ConfirmPassword { get; set; }

		// Role field
		[Required]
		public string Role { get; set; }
	}
}