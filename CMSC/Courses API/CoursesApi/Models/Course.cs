using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesApi.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Term { get; set; }
        public string Subject { get; set; }
        public int Number { get; set; }
        public CourseFormat Format { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDateTBD { get; set; }
        public TimeSpan? SundayTimeStart { get; set; }
        public TimeSpan? SundayTimeEnd { get; set; }
        public TimeSpan? MondayTimeStart { get; set; }
        public TimeSpan? MondayTimeEnd { get; set; }
        public TimeSpan? TuesdayTimeStart { get; set; }
        public TimeSpan? TuesdayTimeEnd { get; set; }
        public TimeSpan? WednesdayTimeStart { get; set; }
        public TimeSpan? WednesdayTimeEnd { get; set; }
        public TimeSpan? ThursdayTimeStart { get; set; }
        public TimeSpan? ThursdayTimeEnd { get; set; }
        public TimeSpan? FridayTimeStart { get; set; }
        public TimeSpan? FridayTimeEnd { get; set; }
        public TimeSpan? SaturdayTimeStart { get; set; }
        public TimeSpan? SaturdayTimeEnd { get; set; }
        public int Credits { get; set; }
        public string Location { get; set; }
        public List<Textbook> RequiredTextbooks { get; set; }
        public List<Textbook> OptionalTextbooks { get; set; }

        public int InstructorId { get; set; }

        [ForeignKey(nameof(InstructorId))]
        public Instructor Instructor { get; set; }
    }
}
