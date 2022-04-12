using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Course number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 1)]
        public string Title { get; set; }

        [Range(0,5)]
        public int Credits { get; set; }

        [DisplayName("Department")]
        public int DepartmentID { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
        public Department Department { get; set; }
    }
}
