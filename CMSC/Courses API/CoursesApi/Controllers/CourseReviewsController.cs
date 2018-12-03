using System.Collections.Generic;
using System.Linq;
using CoursesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class CourseReviewsController : ControllerBase
    {
        private readonly Database _database = new Database();

        // GET api/reviews
        [HttpGet]
        public ActionResult<IEnumerable<CourseReview>> Get()
        {
            return _database.Reviews;
        }

        // GET api/reviews/5
        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            return _database.Reviews.Where(i => i.CourseReviewId == id).FirstOrDefault();
        }
    }
}