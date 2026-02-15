using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GovServe.Models
{
    public class RequiredDocument
    {
        [Key]
        public int DocumentID {  get; set; }

        [Required]
        [ForeignKey(nameof(Service))]
        public int ServiceID { get; set; }

        [Required]
        [StringLength(150)]
        public string DocumentName { get; set; }

        public bool Mandatory {  get; set; }

        //public string DocumentType {  get; set; }

        
        public Service Service { get; set; }

        //public ICollection<CitizenDocument>CitizenDocuments { get; set; }
    }
}
