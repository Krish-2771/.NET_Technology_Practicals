using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCourseRegistration.Models;

namespace StudentCourseRegistration.Controllers
{
    public class StudentController : Controller
    {
        // In-memory storage (no database needed for this activity)
        private static readonly List<Student> _students = new List<Student>
        {
            new Student { Id = 1, Name = "Krish Kothari",    Email = "krish.kothari@gmail.com",    Course = "B.Tech Computer Engineering",      Semester = 5 },
            new Student { Id = 2, Name = "Harshil Jadeja",   Email = "harshil.jadeja@outlook.com", Course = "B.Tech Civil Engineering",         Semester = 7 },
            new Student { Id = 3, Name = "Meera Joshi",      Email = "meera.joshi@yahoo.in",       Course = "B.Tech Electrical Engineering",    Semester = 3 },
            new Student { Id = 4, Name = "Yash Vaghela",     Email = "yash.vaghela@gmail.com",     Course = "BCA",                              Semester = 6 },
            new Student { Id = 5, Name = "Nidhi Parmar",     Email = "nidhi.parmar@gmail.com",     Course = "B.Tech AI & ML Engineering",       Semester = 4 },
            new Student { Id = 6, Name = "Dhruv Solanki",    Email = "dhruv.solanki@outlook.com",  Course = "MCA",                              Semester = 2 },
            new Student { Id = 7, Name = "Riya Chauhan",     Email = "riya.chauhan@gmail.com",     Course = "B.Tech AI & DS Engineering",       Semester = 8 }
        };
        private static int _nextId = 8;   // one more than the last seeded Id

        
        private static readonly object _lock = new object();

        private static readonly string[] _courses =
        {
            "B.Tech Computer Engineering",
            "B.Tech Information & Communication Technology",
            "B.Tech Electrical Engineering",
            "B.Tech Mechanical Engineering",
            "B.Tech Civil Engineering",
            "B.Tech AI & ML Engineering",
            "B.Tech AI & DS Engineering",
            "BCA",
            "MCA"
        };

        // GET: /Student  -> list all students (data passed Controller -> View via model)
        public IActionResult Index()
        {
            List<Student> snapshot;
            lock (_lock) { snapshot = _students.ToList(); }
            return View(snapshot);
        }

        // GET: /Student/Create -> show empty form
        [HttpGet]
        public IActionResult Create()
        {
            LoadCourses();
            return View();
        }

        // POST: /Student/Create -> model binding + validation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                // invalid -> show the same form again with error messages
                LoadCourses();
                return View(student);
            }

            lock (_lock)
            {
                student.Id = _nextId++;
                _students.Add(student);
            }

            TempData["Success"] = $"Student \"{student.Name}\" registered successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: /Student/Details/5
        public IActionResult Details(int id)
        {
            Student student;
            lock (_lock) { student = _students.FirstOrDefault(s => s.Id == id); }

            if (student == null)
            {
                return NotFound($"No student found with Id {id}.");
            }
            return View(student);
        }

        private void LoadCourses()
        {
            // ViewBag: another way of passing data from Controller to View
            ViewBag.Courses = new SelectList(_courses);
        }
    }
}
