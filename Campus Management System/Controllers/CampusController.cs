using Microsoft.AspNetCore.Mvc;
using Campus_Management_System.Models;
using System.Diagnostics.Eventing.Reader;
using System.Transactions;
using System.Linq;
namespace Campus_Management_System.Controllers

{
    public class CampusController : Controller
    {


        static readonly List<Student> studentsList = new List<Student>();

        [HttpPost]
        public IActionResult AddStudent(Student s)
        {

            if (ModelState.IsValid)
            
            {

                int ahmadcount = studentsList.Count(x => x.AssignTeacher == "Ahmad");
                int Alicount = studentsList.Count(x => x.AssignTeacher == "Ali");
                int Raufcount = studentsList.Count(x => x.AssignTeacher == "Rauf");
                int Shericount = studentsList.Count(x => x.AssignTeacher == "Sheri");


                if (s.Department== "Science")
                {
                    s.Department = "Science";

                    
                    if (ahmadcount<= Alicount)
                    {
                        s.AssignTeacher = "Ahmad";

                    } 
                    else
                    {
                        s.AssignTeacher = "Ali";
                    }

                    s.Id = studentsList.Count > 0  ? studentsList.Max(x => x.Id) + 1 : 1;
                    s.MonthlyFees = 5000;
                    s.TotalCourseFees = 5000 * 36;

                }
                
                else if (s.Department=="Arts")
                    
                {

                    if(Raufcount<= Shericount)
                    {
                        s.AssignTeacher = "Rauf";

                    } else
                    {
                        s.AssignTeacher = "Sheri";

                    }

                        s.Department = "Arts";
                    s.MonthlyFees = 3000;
                    s.TotalCourseFees = 3000 * 36;
                    s.Id = studentsList.Count > 0 ? studentsList.Max(x => x.Id) + 1 : 1;

                }
                studentsList.Add(s);
                return RedirectToAction("Index");
            }
            
            else 
            {
                return View(s);
            }
               
        }

        [HttpGet]
        public IActionResult AddStudent()
        {

            return View(new Student());

        }

        public IActionResult Index()
        {
            return View(studentsList);
        }

        public IActionResult DeleteStudent(int id)
        {

            var student = studentsList.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                studentsList.Remove(student);
            }
            return RedirectToAction("index");

        }

        [HttpPost]
        public IActionResult EditStudent(Student updateData)
        {



            int ahmadcount = studentsList.Count(x => x.AssignTeacher == "Ahmad");
            int Alicount = studentsList.Count(x => x.AssignTeacher == "Ali");
            int Raufcount = studentsList.Count(x => x.AssignTeacher == "Rauf");
            int Shericount = studentsList.Count(x => x.AssignTeacher == "Sheri");

            var student = studentsList.FirstOrDefault(x => x.Id == updateData.Id); 

            if (student != null)
            {
                student.Name = updateData.Name;
                student.Age = updateData.Age;
                student.Email = updateData.Email;
                student.Department = updateData.Department;
            
                if (student.Department == "Science")
                
                {
                    student.MonthlyFees = 5000;
                    student.TotalCourseFees = 5000 * 36;
                    if (ahmadcount <= Alicount)
                    {
                        student.AssignTeacher = "Ahmad";

                    }
                    else
                    {
                        student.AssignTeacher = "Ali";
                    }
                }

                else if (student.Department=="Arts")
                
                {
                    student.MonthlyFees = 3000;
                    student.TotalCourseFees = 3000 * 36;

                    if (Raufcount <= Shericount)
                    {
                        student.AssignTeacher = "Rauf";

                    }
                    else
                    {
                        student.AssignTeacher = "Sheri";

                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditStudent( int id)
        {
            var student = studentsList.FirstOrDefault(x => x.Id ==id);

                if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
