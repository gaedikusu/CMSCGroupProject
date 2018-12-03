using System;

namespace CoursesApi.Models
{
    public class Textbook
    {
        public int TextbookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string ImageUrl { get; set; }
    }
}
