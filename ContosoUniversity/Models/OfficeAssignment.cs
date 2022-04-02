using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }

        [DisplayName("Office location")]
        [StringLength(50, MinimumLength = 1)]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
