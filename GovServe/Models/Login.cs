using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace GovServe.Models
{
	
	public class Login
    {
		[Key]
		public int Id { get; set; }

		[Required, EmailAddress, MaxLength(100)]
		public string Email { get; set; }

		[Required]
		public string Password{ get; set; }


		[Required]
		[Compare("Password", ErrorMessage = "Password and ConfirmPassword Not Match")]
		public string ConfirmPassword { get; set; }

		// Role field
		[Required]
		public string Role { get; set; }
	
	}
}
