using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GovServe.Models
{
	public class CitizenDocument
	{
		[Key]
		public int CitizenDocumentID { get; set; }

		[Required]
		public int ApplicationID { get; set; }
		[ForeignKey("ApplicationID")]
		public virtual Applications Application { get; set; }

		//[Required]
		//public int DocumentID { get; set; }
		//[ForeignKey("DocumentID")]
		//public virtual RequiredDocument Required { get; set; }

		[Required, MaxLength(100)]
		public string DocumentType { get; set; }

		[Required]
		public string FilePath { get; set; }

		[Required]
		public DateTime UploadedDate { get; set; }

		[Required, MaxLength(50)]
		public string VerificationStatus { get; set; }
	}
}