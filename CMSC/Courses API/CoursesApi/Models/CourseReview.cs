using System;

namespace CoursesApi.Models
{
    public class CourseReview
    {
        public int CourseReviewId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Course Course { get; set; }
        public int StarRating { get; set; }
        public DateTime PostDate { get; set; }
    }
}