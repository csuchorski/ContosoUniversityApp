using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolContext _context;

        public CourseController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = _context.Courses.Include(c => c.Department).ToList();
            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var course = _context.Courses.Find(id);

            if (course == null) return NotFound();

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            return View(course);
        }
    }
}
