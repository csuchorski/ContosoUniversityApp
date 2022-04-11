using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;

namespace ContosoUniversity.Controllers
{
    public class InstructorController : Controller
    {
        private readonly SchoolContext _context;

        public InstructorController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Instructor
        public async Task<IActionResult> Index(int? id, int? courseID)
        {
            InstructorIndexData instructorViewModel = new InstructorIndexData();
            instructorViewModel.Instructors = await _context.Instructors.
            Include(m => m.OfficeAssignment).
            Include(m => m.CourseAssignments).
                ThenInclude(m => m.Course).
                    ThenInclude(m => m.Enrollments).
                        ThenInclude(m => m.Student).
            Include(m => m.CourseAssignments).
                ThenInclude(m => m.Course).
                    ThenInclude(m => m.Department).
            AsNoTracking().
            OrderBy(m => m.LastName).
            ToListAsync();

            if (id != null)
            {
                ViewData["InstructorID"] = id.Value;
                Instructor instructor = instructorViewModel.Instructors.Where(i => i.ID == id.Value).Single();
                instructorViewModel.Courses = instructor.CourseAssignments.Select(s => s.Course);

            }

            if (courseID != null)
            {
                ViewData["CourseID"] = courseID.Value;
                instructorViewModel.Enrollments = instructorViewModel.Courses.Where(s => s.CourseID == courseID).Single().Enrollments;
            }


            return View(instructorViewModel);
        }

        // GET: Instructor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // GET: Instructor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastName,FirstMidName,HireTime")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        // GET: Instructor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors.Include(m => m.OfficeAssignment).Include(m => m.CourseAssignments).
                ThenInclude(c => c.Course).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (instructor == null)
            {
                return NotFound();
            }
            PopulateAssignedCourse(instructor);

            return View(instructor);
        }

        private void PopulateAssignedCourse(Instructor instructor)
        {
            var allCourses = _context.Courses;
            var assignedCourses = new HashSet<int>(instructor.CourseAssignments.Select(m => m.CourseID));

            var viewModel = new List<AssignedCourseData>();

            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    IsAssigned = assignedCourses.Contains(course.CourseID)
                });
            }
            ViewData["Courses"] = viewModel;
        }

        // POST: Instructor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedCourses)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorToChange = await _context.Instructors.Include(m => m.OfficeAssignment).
                Include(m => m.CourseAssignments).ThenInclude(m => m.Course).FirstOrDefaultAsync(m => m.ID == id);

            if (await TryUpdateModelAsync<Instructor>(instructorToChange, "", m => m.FirstMidName, m => m.LastName, m => m.HireTime, m => m.OfficeAssignment))
            {
                if (String.IsNullOrWhiteSpace(instructorToChange.OfficeAssignment?.Location))
                {
                    instructorToChange.OfficeAssignment = null;
                }

                ChangeInstructorCourses(selectedCourses, instructorToChange);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(instructorToChange);
        }

        public void ChangeInstructorCourses(string[] selectedCourses, Instructor instructorToChange)
        {
            if (selectedCourses == null)
            {
                instructorToChange.CourseAssignments = new List<CourseAssignment>();
                return;
            }

            HashSet<string> selectedCoursesHS = new HashSet<string>(selectedCourses);
            HashSet<int> instructorCoursesHS = new HashSet<int>(instructorToChange.CourseAssignments.Select(c => c.Course.CourseID));

            foreach (var course in _context.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!instructorCoursesHS.Contains(course.CourseID))
                    {
                        instructorToChange.CourseAssignments.Add(new CourseAssignment { CourseID = course.CourseID, InstructorID = instructorToChange.ID });
                    }
                }
                else
                {
                    if(instructorCoursesHS.Contains(course.CourseID))
                    {
                        CourseAssignment courseToRemove = instructorToChange.CourseAssignments.FirstOrDefault(m=>m.CourseID == course.CourseID);
                        instructorToChange.CourseAssignments.Remove(courseToRemove);
                    }
                }
            }
        }

        // GET: Instructor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.ID == id);
        }
    }
}
