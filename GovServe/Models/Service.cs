using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GovServe.Models
{
    public class Service
    {
        [Key]
        public int ServiceID {  get; set; }

        [Required]
        [ StringLength(150,MinimumLength =5)]
        public string ServiceName { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public int SLA_Days {  get; set; }
        public bool Status {  get; set; }

        [Required]
        [ForeignKey(nameof(Department))]
        public int DepartmentID {  get; set; }
        public Department Department { get; set; }

        [Required]
        public DateTime CreatedOn {  get; set; }= DateTime.Now;

        public ICollection<EligibilityRule> EligibilityRules {  get; set; }

        public ICollection<RequiredDocument> RequiredDocuments {  get; set; }

        //public ICollection<WorkflowStage> WorkFlowStages { get; set; }

        //public ICollection<ServiceReoprt>ServiceReports { get; set; }



    }
}
