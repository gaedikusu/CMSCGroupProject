using CoursesApi.Models;
using System;
using System.Collections.Generic;

namespace CoursesApi
{
    public static class TestDatabase
    {
        public static void AddTestEntities(Database db)
        {
            // ------------------------------------------------------
            // INSTRUCTORS
            // ------------------------------------------------------
            var instr1 = new Instructor
            {
                FirstName = "Matt",
                LastName = "Saville",
                Department = "Mathematics"
            };
            var instr2 = new Instructor
            {
                FirstName = "Smitty",
                LastName = "Werbenjagermanjensen",
                Department = "Mathematics"
            };
            db.Instructors.AddRange(instr1, instr2);

            // ------------------------------------------------------
            // TEXTBOOKS
            // ------------------------------------------------------
            var textbook1 = new Textbook
            {
                Title = "Calculus: An Intuitive and Physical Approach (Second Edition)",
                Description = "Application-oriented introduction relates the subject as closely as possible to science. In-depth explorations of the derivative, the differentiation and integration of the powers of x, and theorems on differentiation and antidifferentiation lead to a definition of the chain rule and examinations of trigonometric functions, logarithmic and exponential functions, techniques of integration, polar coordinates, much more. Clear-cut explanations, numerous drills, illustrative examples. 1967 edition. Solution guide available upon request.",
                ISBN = "978-0486404530",
                ImageUrl = "https://i.imgur.com/9Ly4XCY.png"
            };
            db.Textbooks.AddRange(textbook1);

            // ------------------------------------------------------
            // COURSES
            // ------------------------------------------------------
            db.Courses.AddRange(
                new Course
                {
                    Title = "Calculus I",
                    Description = "Prerequisite: MATH 108 or MATH 115. An introduction to calculus.The goal is to demonstrate fluency in the language of calculus; discuss mathematical ideas appropriately; and solve problems by identifying, representing, and modeling functional relationships. Topics include functions, the sketching of graphs of functions, limits, continuity, derivatives and applications of the derivative, definite and indefinite integrals, and calculation of area. Students may receive credit for only one of the following courses: MATH 130, MATH 131, or MATH 140.",
                    Term = 201901,
                    Subject = "MATH",
                    Number = 140,
                    StartDate = DateTime.Parse("2019/01/14"),
                    EndDate = DateTime.Parse("2019/03/10"),
                    IsDateTBD = false,
                    Credits = 4,
                    Location = "Online",
                    Instructor = instr1,
                    Format = CourseFormat.Hybrid,
                    RequiredTextbooks = new List<Textbook> { textbook1 }
                },
                new Course
                {
                    Title = "Calculus II",
                    Description = "(A continuation of MATH 140.) Prerequisite: MATH 140. A study of integration and functions.The aim is to demonstrate fluency in the language of calculus; discuss mathematical ideas appropriately; model and solve problems using integrals and interpret the results; and use infinite series to approximate functions to model real-world scenarios.Focus is on techniques of integration, improper integrals, and applications of integration (such as volumes, work, arc length, and moments); inverse, exponential, and logarithmic functions; and sequences and series. Students may receive credit for only one of the following courses: MATH 131, MATH 132, or MATH 141.",
                    Term = 201901,
                    Subject = "MATH",
                    Number = 141,
                    StartDate = DateTime.Parse("2019/01/14"),
                    EndDate = DateTime.Parse("2019/03/10"),
                    IsDateTBD = false,
                    Credits = 4,
                    Location = "Online",
                    Instructor = instr2,
                    Format = CourseFormat.Online,
                    RequiredTextbooks = new List<Textbook> { textbook1 }
                }
            );
        }
    }
}
