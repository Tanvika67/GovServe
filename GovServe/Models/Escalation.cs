using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GovServe.Models
{
	public class Escalation
	{
		[Key]
		public int EscalationId { get; set; }
		[Required]
		public int CaseId {  get; set; }
		public int? RaisedByUserId { get; set; }
		public string Reason { get; set; }
		public string Status { get; set; }
		public DateTime CreatedDate { get; set; }

	}
}
