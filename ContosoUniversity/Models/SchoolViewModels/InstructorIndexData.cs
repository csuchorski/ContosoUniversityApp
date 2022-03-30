using System.Collections;
using System.Collections.Generic;

namespace ContosoUniversity.Models.SchoolViewModels
{
    public class InstructorIndexData
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
