using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int Id { get; set; }

        [DisplayName("First and middle name")]
        [StringLength(50, MinimumLength = 1)]
        public string FirstMidName { get; set; }

        [DisplayName("Last name")]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        public string FullName 
        {
            get { return $"{FirstMidName} {LastName}"; }
        }

        [DisplayName("Enrollment date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
