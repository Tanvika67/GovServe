using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GovServe.Controllers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GovServe.Models
{
	public class Escalation
	{
		[Key]
		public int EscalationId { get; set; }
		[Required]
		[ForeignKey("Case")]
		public int CaseId {  get; set; }
		// public virtual Cases CaseId { get; set; }
		public int? RaisedByUserId { get; set; }
		public string Reason { get; set; }

		public string Status { get; set; }
		public DateTime CreatedDate { get; set; }

	}
}
