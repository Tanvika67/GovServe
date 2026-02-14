using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GovServe.Models
{
    public class ServiceReport
    {
        [Key]
        public int ReportID { get; set; }

        [Required]
        public string Scope { get; set; }

        [Required]
        public string Metrics { get; set; }

        [Required]
        public DateTime ReportDate { get; set; } = DateTime.Now;
    }
}
