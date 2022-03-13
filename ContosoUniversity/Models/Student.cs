using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int Id { get; set; }
        [DisplayName("First and middle name")]
        public string FirstMidName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("Enrollment date")]
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
