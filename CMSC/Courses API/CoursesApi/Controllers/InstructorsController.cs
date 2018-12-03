using System.Collections.Generic;
using System.Linq;
using CoursesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly Database _database = new Database();

        // GET api/instructors
        [HttpGet]
        public ActionResult<IEnumerable<Instructor>> Get()
        {
            return _database.Instructors;
        }

        // GET api/instructors/5
        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            return _database.Instructors.Where(i => i.InstructorId == id).FirstOrDefault();
        }
    }
}