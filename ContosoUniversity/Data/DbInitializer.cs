using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
           // context.Database.EnsureCreated();
            //Student[] students;
            if (!context.Students.Any())
            {
                var students = new Student[]
               {
                    new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                    new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                    new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
               };
                foreach (var student in students)
                {
                    context.Students.Add(student);
                }
                context.SaveChanges();
            }

            //Instructors 
            if (!context.Instructors.Any())
            {
                var instructors = new Instructor[]
                {
                    new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie",
                        HireTime = DateTime.Parse("1995-03-11") },
                    new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",
                        HireTime = DateTime.Parse("2002-07-06") },
                    new Instructor { FirstMidName = "Roger",   LastName = "Harui",
                        HireTime = DateTime.Parse("1998-07-01") },
                    new Instructor { FirstMidName = "Candace", LastName = "Kapoor",
                        HireTime = DateTime.Parse("2001-01-15") },
                    new Instructor { FirstMidName = "Roger",   LastName = "Zheng",
                        HireTime = DateTime.Parse("2004-02-12") }
                };

                foreach (Instructor i in instructors)
                {
                    context.Instructors.Add(i);
                }
                context.SaveChanges();
            }
            //Departments
            if (!context.Departments.Any())
            {
                var departments = new Department[]
                {
                    new Department { Name = "English",     Budget = 350000,
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = context.Instructors.Single( i => i.LastName == "Abercrombie").ID },
                    new Department { Name = "Mathematics", Budget = 100000,
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = context.Instructors.Single( i => i.LastName == "Fakhouri").ID },
                    new Department { Name = "Engineering", Budget = 350000,
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = context.Instructors.Single( i => i.LastName == "Harui").ID },
                    new Department { Name = "Economics",   Budget = 100000,
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = context.Instructors.Single( i => i.LastName == "Kapoor").ID }
                };

                foreach (Department d in departments)
                {
                    context.Departments.Add(d);
                }
                context.SaveChanges();
            }

            //Courses
            if (!context.Courses.Any())
            {
                var courses = new Course[]
                {
                     new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                         DepartmentID = context.Departments.Single( s => s.Name == "Engineering").DepartmentID
                     },
                     new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                         DepartmentID = context.Departments.Single( s => s.Name == "Economics").DepartmentID
                     },
                     new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                         DepartmentID = context.Departments.Single( s => s.Name == "Economics").DepartmentID
                     },
                     new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
                         DepartmentID = context.Departments.Single( s => s.Name == "Mathematics").DepartmentID
                     },
                     new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                         DepartmentID = context.Departments.Single( s => s.Name == "Mathematics").DepartmentID
                     },
                     new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                         DepartmentID = context.Departments.Single( s => s.Name == "English").DepartmentID
                     },
                     new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
                         DepartmentID = context.Departments.Single( s => s.Name == "English").DepartmentID
                    },
                };

                foreach (var course in courses)
                {
                    context.Courses.Add(course);
                }
                context.SaveChanges();
            }

            if (!context.OfficeAssignments.Any())
            {
                var officeAssignments = new OfficeAssignment[]
                {
                    new OfficeAssignment {
                        InstructorID = context.Instructors.Single( i => i.LastName == "Fakhouri").ID,
                        Location = "Smith 17" },
                    new OfficeAssignment {
                        InstructorID = context.Instructors.Single( i => i.LastName == "Harui").ID,
                        Location = "Gowan 27" },
                    new OfficeAssignment {
                        InstructorID = context.Instructors.Single( i => i.LastName == "Kapoor").ID,
                        Location = "Thompson 304" },
                };

                foreach (OfficeAssignment o in officeAssignments)
                {
                    context.OfficeAssignments.Add(o);
                }
                context.SaveChanges();
            }

            if (!context.CourseAssignments.Any())
            {
                var courseAssignments = new CourseAssignment[]
                {
                    new CourseAssignment {
                        CourseID = context.Courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        InstructorID = context.Instructors.Single(i => i.LastName == "Kapoor").ID
                        },
                    new CourseAssignment {
                        CourseID = context.Courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        InstructorID = context.Instructors.Single(i => i.LastName == "Harui").ID
                        },
                    new CourseAssignment {
                        CourseID = context.Courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                        InstructorID = context.Instructors.Single(i => i.LastName == "Zheng").ID
                        },
                    new CourseAssignment {
                        CourseID = context.Courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                        InstructorID = context.Instructors.Single(i => i.LastName == "Zheng").ID
                        },
                    new CourseAssignment {
                        CourseID = context.Courses.Single(c => c.Title == "Calculus" ).CourseID,
                        InstructorID = context.Instructors.Single(i => i.LastName == "Fakhouri").ID
                        },
                    new CourseAssignment {
                        CourseID = context.Courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                        InstructorID = context.Instructors.Single(i => i.LastName == "Harui").ID
                        },
                    new CourseAssignment {
                        CourseID = context.Courses.Single(c => c.Title == "Composition" ).CourseID,
                        InstructorID = context.Instructors.Single(i => i.LastName == "Abercrombie").ID
                        },
                    new CourseAssignment {
                        CourseID = context.Courses.Single(c => c.Title == "Literature" ).CourseID,
                        InstructorID = context.Instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
                };

                foreach (CourseAssignment ci in courseAssignments)
                {
                    context.CourseAssignments.Add(ci);
                }
                context.SaveChanges();
            }

            //Enrollments
            if (!context.Enrollments.Any())
            {
                var enrollments = new Enrollment[]
                {
                    new Enrollment {
                        StudentID = context.Students.Single(s => s.LastName == "Alexander").ID,
                        CourseID = context.Courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        Grade = Grade.A
                    },
                    new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = context.Students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = context.Students.Single(s => s.LastName == "Alonso").ID,
                        CourseID = context.Courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                        Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = context.Students.Single(s => s.LastName == "Alonso").ID,
                        CourseID = context.Courses.Single(c => c.Title == "Composition" ).CourseID,
                        Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = context.Students.Single(s => s.LastName == "Anand").ID,
                        CourseID = context.Courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = context.Students.Single(s => s.LastName == "Anand").ID,
                        CourseID = context.Courses.Single(c => c.Title == "Microeconomics").CourseID,
                        Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = context.Students.Single(s => s.LastName == "Barzdukas").ID,
                        CourseID = context.Courses.Single(c => c.Title == "Chemistry").CourseID,
                        Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = context.Students.Single(s => s.LastName == "Li").ID,
                        CourseID = context.Courses.Single(c => c.Title == "Composition").CourseID,
                        Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = context.Students.Single(s => s.LastName == "Justice").ID,
                        CourseID = context.Courses.Single(c => c.Title == "Literature").CourseID,
                        Grade = Grade.B
                    }
                };

                foreach (Enrollment e in enrollments)
                {
                    var enrollmentInDataBase = context.Enrollments.Where(
                        s =>
                                s.Student.ID == e.StudentID &&
                                s.Course.CourseID == e.CourseID).SingleOrDefault();
                    if (enrollmentInDataBase == null)//If the student isn't enrolled yet, adds to DB
                    {
                        context.Enrollments.Add(e);
                    }
                }
                context.SaveChanges();
            }

        }
    }
}
