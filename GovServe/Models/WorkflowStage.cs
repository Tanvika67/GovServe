using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GovServe.Models
{
    public class WorkflowStage
    {
        [Key]
        public int StageID { get; set; }

        [Required]
        [ForeignKey(nameof(Service))]
        public Service ServiceID { get; set; }
        public Service Service { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleResponsoble { get; set; }

        [Range(1,20)]
        public int SequenceNumber { get; set; }

        //[Range(1, 365)]
        //public int SLA_Days { get; set; }

        //public ICollection<EscalationMatrix> EscalationMatrices { get; set; }

        //public ICollection<SLARecord>SLARecords { get; set; }

    }
}
