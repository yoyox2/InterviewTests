using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasCredits()
        {
            var tracker = new GraduationTracker();

            var diploma = new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new[]
                {
                    new Requirement { Id = 100, Name = "Math", MinimumMark = 50, Courses = new int[] { 1 }, Credits = 1 },
                    new Requirement { Id = 102, Name = "Science", MinimumMark = 50, Courses = new int[] { 2 }, Credits = 1 },
                    new Requirement { Id = 103, Name = "Literature", MinimumMark = 50, Courses = new int[] { 3 }, Credits = 1},
                    new Requirement { Id = 104, Name = "Physichal Education", MinimumMark = 50, Courses = new int[] { 4 }, Credits = 1 }
                }
            };

            var students = new[]
            {
                new Student
                {
                    Id = 1,
                    Courses = new Course[]
                    {
                         new Course { Id = 1, Name = "Math", Mark = 95 },
                         new Course { Id = 2, Name = "Science", Mark = 95 },
                         new Course { Id = 3, Name = "Literature", Mark = 95 },
                         new Course { Id = 4, Name = "Physichal Education", Mark = 49 }
                        // Changed Mark of the last course to under the minimum mark in order to check if student 1 can graduate without fulfilling a credit requirement of diploma.
                    }
                },
                new Student
                {
                    Id = 2,
                    Courses = new Course[]
                    {
                         new Course { Id = 1, Name = "Math", Mark = 80 },
                         new Course { Id = 2, Name = "Science", Mark = 80 },
                         new Course { Id = 3, Name = "Literature", Mark = 80 },
                         new Course { Id = 4, Name = "Physichal Education", Mark = 80 }
                    }
                },
                new Student
                {
                    Id = 3,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark = 50 },
                        new Course{Id = 2, Name = "Science", Mark = 50 },
                        new Course{Id = 3, Name = "Literature", Mark = 50 },
                        new Course{Id = 4, Name = "Physichal Education", Mark = 50 }
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark = 40 },
                        new Course{Id = 2, Name = "Science", Mark = 40 },
                        new Course{Id = 3, Name = "Literature", Mark = 40 },
                        new Course{Id = 4, Name = "Physichal Education", Mark = 40 }
                    }
                },
                new Student //Added 5th Student to check SumaCumLaude standing.
                {
                    Id = 5,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark = 100 },
                        new Course{Id = 2, Name = "Science", Mark = 100 },
                        new Course{Id = 3, Name = "Literature", Mark = 100 },
                        new Course{Id = 4, Name = "Physichal Education", Mark = 100 }
                    }
                }
            };

            var graduated = new List<Student>();

            foreach (var student in students)
            {
                graduated.Add(tracker.HasGraduated(diploma, student));
            }

            //Student 1
            Assert.IsFalse(graduated.Any(student => student.IsGraduated == true
                && student.Credits < diploma.Credits
                && student.Standing == STANDING.MagnaCumLaude));

            //Student 2
            Assert.IsFalse(graduated.Any(student => student.IsGraduated == false
                && student.Credits == diploma.Credits
                && student.Standing == STANDING.MagnaCumLaude));

            //Student 3
            Assert.IsFalse(graduated.Any(student => student.IsGraduated == false && student.Standing == STANDING.Average));

            //Student 4
            Assert.IsFalse(graduated.Any(student => student.IsGraduated == true && student.Standing == STANDING.Remedial));

            //Student 5
            Assert.IsFalse(graduated.Any(student => student.IsGraduated == false && student.Standing == STANDING.SumaCumLaude));
        }


    }
}
