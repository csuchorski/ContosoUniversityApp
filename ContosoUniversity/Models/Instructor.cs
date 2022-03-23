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
        public string LastName { get; set; }
        [DisplayName("First Name")]
        public int FirstMidName { get; set; }
        public DateTime HireTime { get; set; }

        public ICollection<CourseAssignment> CourseAssignments;
        public ICollection<OfficeAssignment> OfficeAssignments;
    }
}
