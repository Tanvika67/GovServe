using System.ComponentModel.DataAnnotations;

namespace GovServe.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required,StringLength(100)]
        public string DepartmentName { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public bool IsActive{  get; set; }=true;

        //public ICollection<Service> Services { get; set; }
    }
}
