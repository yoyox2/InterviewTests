using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class Student
    {
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        public STANDING Standing { get; set; } = STANDING.None;
        public bool IsGraduated { get; set; } = false;  //A flag of graduation to remove Tuple.
        public int Credits { get; set; } = 0;           //New field to store total credits a student earns
    }
}
