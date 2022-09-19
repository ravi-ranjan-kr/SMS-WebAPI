using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementDomainLayer.Models
{
    public class StudentMarks
    {
        [Key]
        public int SrNo { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [Required]
        public int StuMarks { get; set; }
        public int StuSem { get; set; }
    }
}
