using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GovServe.Models
{
	public class Applications
	{
		[Key]
		public int ApplicationID { get; set; }

		// Foreign key to Registration
		[Required]
		public int UserId { get; set; }
		[ForeignKey("UserId")]
		public virtual Registration User { get; set; }

		//// Foreign key to Service
		//[Required]
		//public int ServiceID { get; set; }
		//[ForeignKey("ServiceID")]
		//public virtual Service Service { get; set; }

		[Required]
		public DateTime SubmittedDate { get; set; }

		// Foreign key to Workflow
		//[Required]
		//public int WorkflowStatus { get; set; }
		//[ForeignKey("WorkflowStatus")]
		//public virtual WorkFlow WorkFlow { get; set; }

		[MaxLength(50)]
		public string Status { get; set; }

		public virtual ICollection<CitizenDocument> CitizenDocuments { get; set; }
	}
}