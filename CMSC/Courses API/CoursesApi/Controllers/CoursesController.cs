using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CoursesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly Database _database = new Database();

        // GET api/courses
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get([FromQuery] string start, [FromQuery] string end, [FromQuery] string days, [FromQuery] int? instructorId, [FromQuery] string format, [FromQuery] string subject, [FromQuery] int? term, [FromQuery] int? courseNumber)
        {
            var courses = _database.Set<Course>()
                .Include(x => x.Instructor)
                .Include(x => x.RequiredTextbooks)
                .Include(x => x.OptionalTextbooks)
                .AsEnumerable();

            // ----------------------------------------------------------------
            // Filter by start time
            // ----------------------------------------------------------------
            TimeSpan? startTime = null;
            if (start != null)
            {
                var startDateTime = DateTime.ParseExact(start, "H:mm", CultureInfo.InvariantCulture);
                startTime = startDateTime - startDateTime.Date;

                courses = from c in courses
                          where
                          c.SundayTimeStart.HasValue && c.SundayTimeStart.Value >= startTime ||
                          c.MondayTimeStart.HasValue && c.MondayTimeStart.Value >= startTime ||
                          c.TuesdayTimeStart.HasValue && c.TuesdayTimeStart.Value >= startTime ||
                          c.WednesdayTimeStart.HasValue && c.WednesdayTimeStart.Value >= startTime ||
                          c.ThursdayTimeStart.HasValue && c.ThursdayTimeStart.Value >= startTime ||
                          c.FridayTimeStart.HasValue && c.FridayTimeStart.Value >= startTime ||
                          c.SaturdayTimeStart.HasValue && c.SaturdayTimeStart.Value >= startTime
                          select c;
            }

            // ----------------------------------------------------------------
            // Filter by end time
            // ----------------------------------------------------------------
            TimeSpan? endTime = null;
            if (end != null)
            {
                var endDateTime = DateTime.ParseExact(start, "H:mm", CultureInfo.InvariantCulture);
                endTime = endDateTime - endDateTime.Date;

                courses = from c in courses
                          where
                          c.SundayTimeEnd.HasValue && c.SundayTimeEnd.Value >= endTime ||
                          c.MondayTimeEnd.HasValue && c.MondayTimeEnd.Value >= endTime ||
                          c.TuesdayTimeEnd.HasValue && c.TuesdayTimeEnd.Value >= endTime ||
                          c.WednesdayTimeEnd.HasValue && c.WednesdayTimeEnd.Value >= endTime ||
                          c.ThursdayTimeEnd.HasValue && c.ThursdayTimeEnd.Value >= endTime ||
                          c.FridayTimeEnd.HasValue && c.FridayTimeEnd.Value >= endTime ||
                          c.SaturdayTimeEnd.HasValue && c.SaturdayTimeEnd.Value >= endTime
                          select c;
            }

            // ----------------------------------------------------------------
            // Filter by days
            // ----------------------------------------------------------------
            if (days != null)
            {
                string[] onDays = days.Split(',').Select(s => s.ToLowerInvariant()).ToArray();
                

                // TODO
            }

            // ----------------------------------------------------------------
            // Filter by instructor
            // ----------------------------------------------------------------
            if (instructorId.HasValue)
            {
                courses = from c in courses
                          where c.InstructorId == instructorId.Value
                          select c;
            }

            // ----------------------------------------------------------------
            // Filter by course format
            // ----------------------------------------------------------------
            if (format != null)
            {
                var courseFormat = (CourseFormat)Enum.Parse(typeof(CourseFormat), format);

                courses = from c in courses
                          where c.Format == courseFormat
                          select c;
            }

            // ----------------------------------------------------------------
            // Filter by subject
            // ----------------------------------------------------------------
            if (subject != null)
            {
                courses = from c in courses
                          where c.Subject.ToLowerInvariant() == subject.ToLowerInvariant()
                          select c;
            }

            // ----------------------------------------------------------------
            // Filter by term
            // ----------------------------------------------------------------
            if (term.HasValue)
            {
                courses = from c in courses
                          where c.Term == term.Value
                          select c;
            }

            // ----------------------------------------------------------------
            // Filter by course number
            // ----------------------------------------------------------------
            if (courseNumber.HasValue)
            {
                courses = from c in courses
                          where c.Number == courseNumber.Value
                          select c;
            }

            return new ActionResult<IEnumerable<Course>>(courses);
        }

        // GET api/courses/5
        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            return _database.Courses.Where(c => c.CourseId == id).FirstOrDefault();
        }
    }
}
