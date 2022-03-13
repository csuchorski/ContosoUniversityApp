﻿using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext _context;
        public StudentController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var studentList = _context.Students.ToList();
            return View(studentList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var obj = _context.Students.Find(id);
            if (obj == null) return NotFound();
            return View(obj);
        }
        
    }
}
