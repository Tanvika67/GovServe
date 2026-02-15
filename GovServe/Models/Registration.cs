using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GovServe.Models
{
	public class Registration
	{
		[Key]
		public int UserId { get; set; }   // Primary Key

		[Required]
		[EmailAddress]
		[MaxLength(100)]
		public string Email { get; set; }   // Primary Key here

		[Required, MaxLength(100)]
		public string FullName { get; set; }

		[Required, MaxLength(15)]
		public string Phone { get; set; }

		[Required]
		public string PasswordHash { get; set; }

		[NotMapped] // not stored in DB, only for validation
		public string ConfirmPassword { get; set; }

		// Role can be added later with a proper FK
		// public int Role { get; set; }
		// [ForeignKey("Role")]
		// public virtual Role Role { get; set; }

		public virtual ICollection<Applications> Applications { get; set; }

	}
}