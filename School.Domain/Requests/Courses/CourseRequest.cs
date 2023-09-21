using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Requests.Courses
{
    public class CourseRequest
    {
        public required string CourseName { get; set; }
        public int IdMember { get; set; }
        public bool IsActive { get; set; }
        public required DateTime CreatedDate { get; set; }
    }
}
