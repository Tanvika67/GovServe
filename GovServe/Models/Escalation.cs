using System.ComponentModel.DataAnnotations;

namespace GovServe.Models
{
    public class Escalation
    {
        [Key]
        public int EscalationId { get; set; }
        public int CaseId {  get; set; }
        public string RaisedBy { get; set; }
        public string Reason { get; set; }
        public int EscalatedTo {  get; set; }
        public DateOnly Date {  get; set; }
        public string status {  get; set; }
    }
}
