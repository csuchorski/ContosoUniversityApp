using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Last Name")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [DisplayName("First Name")]
        [Required]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        public string FullName
        {
            get { return $"{FirstMidName} {LastName}"; }
        }

        [DataType(DataType.Date)]
        [DisplayName("Hire Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireTime { get; set; }

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public ICollection<OfficeAssignment> OfficeAssignments { get; set; }
    }
}
