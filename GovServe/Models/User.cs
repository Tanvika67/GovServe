using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GovServe.Models
{
    public class User
    {
		[Key]
		public int UserId { get; set; }

		[Required]
		[MaxLength(100)]
		public string FullName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MaxLength(15)]
		public string Phone { get; set; }

		[Required]

		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,}$",
		ErrorMessage = "Password must contain at least 1 uppercase, 1 lowercase, 1 number, and 1 special character.")]

		public string Password { get; set; }
		[Required]
		[Compare("Password",ErrorMessage ="Password and ConfirmPassword Not Match")]
		public string ConfirmPassword { get; set;}

		[Required]
		public string Role { get; set; }
		
		// Navigation Property
		//public virtual ICollection<Applications> Applications { get; set; }
	}
}
