using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GovServe.Models
{
    public class EligibilityRule
    {
        [Key]
        public int RuleID { get; set; }

        [Required]
        [StringLength(300)]
        public string RuleDescription {  get; set; }

        public string RuleExpression {  get; set; }

        [Required]
        [ForeignKey(nameof(Service))]
        public int ServiceID {  get; set; }
        public Service Service { get; set; }

    }
}
