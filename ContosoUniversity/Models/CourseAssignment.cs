using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class CourseAssignment
    {
        public int CourseID { get; set; }
        public int InstructorID { get; set; }

        public Course Course;
        public Instructor Instructor;
    }
}
