using System.Collections.Generic;
using System.Linq;
using CoursesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextbooksController : ControllerBase
    {
        private readonly Database _database = new Database();

        // GET api/textbooks
        [HttpGet]
        public ActionResult<IEnumerable<Textbook>> Get()
        {
            return _database.Textbooks;
        }

        // GET api/textbooks/5
        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {
            return _database.Textbooks.Where(i => i.TextbookId == id).FirstOrDefault();
        }
    }
}