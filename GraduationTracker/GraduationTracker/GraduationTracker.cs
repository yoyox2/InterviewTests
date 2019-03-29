using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public class GraduationTracker
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="diploma"></param>
        /// <param name="student"></param>
        /// <returns>Student</returns>
        public Student HasGraduated(Diploma diploma, Student student)
        {
            int credits = 0;
            int average = 0;

            foreach (var d in diploma.Requirements)
            {
                Requirement requirement = d; //No repository usage for testing test cases.

                foreach (var s in student.Courses)
                {
                    foreach (var requiredCourse in requirement.Courses)
                    {
                        if (requiredCourse == s.Id)
                        {
                            average += s.Mark;

                            if (s.Mark >= requirement.MinimumMark)
                            {
                                credits += requirement.Credits;
                            }
                        }
                    }
                }
            }

            average = average / student.Courses.Length;

            student.Credits = credits;
            student.IsGraduated = true;

            if (diploma.Credits > credits)
            {
                student.IsGraduated = false;
            }

            if (average < 50)
            {
                student.Standing = STANDING.Remedial;
                student.IsGraduated = false;
            }
            else if (average < 80)
            {
                student.Standing = STANDING.Average;
            }
            else if (average < 95)
            {
                student.Standing = STANDING.MagnaCumLaude;
            }
            else
            {
                student.Standing = STANDING.SumaCumLaude;
            }

            return student;
        }
    }
}
