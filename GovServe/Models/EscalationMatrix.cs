using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GovServe.Models
{
    public class EscalationMatrix
    {
        [Key]
        public int EscalationID { get; set; }

        [Required]
        [ForeignKey(nameof(WorkflowStage))]
        public int StageID { get; set; }

        public int EscalateLevel { get; set; }

        [Range(1, 60)]
        public int EscalateAfterDays { get; set; }

        //[Required]
        //public  UserRole EscalationRole { get; set; }


        public WorkflowStage WorkflowStage { get; set; }
    }
}
