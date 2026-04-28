using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Campus_Management_System.Models
{
    public class Student


    {


        public int Id { get; set; }


        public string? Name { get; set; }

        [Range(minimum:18, maximum:100)]
        public int Age { get; set; }

        public decimal MonthlyFees { get; set; }

        public decimal TotalCourseFees { get; set; }
        public string? Department { get; set; }

        public string? AssignTeacher { get; set; }
        public string? Email { get; set; }

      [Range(minimum: 18, maximum: 1000)]

     public decimal? Gpa { get; set; }


    }
}
