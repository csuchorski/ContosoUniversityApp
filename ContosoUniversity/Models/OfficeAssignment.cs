using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        public int InstructorID { get; set; }
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
