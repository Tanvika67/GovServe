using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GovServe.Models
{
    public class Cases
    {
        [Key]
        public int CaseId {  get; set; }
        [ForeignKey("ApplicationId")]
        public int ApplicationId{ get; set; }
		[Required]
		public int AssignedOfficerId {  get; set; }
        public DateTime AssignedDate { get; set; }
		public DateTime LastUpdated { get; set; }
		public string Status { get; set; }
        
        
         
    }
    
}
