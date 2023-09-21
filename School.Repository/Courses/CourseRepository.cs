using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using School.Domain;
using School.Domain.Options;
using School.Domain.Requests.Courses;
using School.Domain.Responses.Course;
using System.Data;

namespace School.Repository.Cursos
{
    public sealed class CourseRepository : ICourseRepository
    {
        private readonly DBContextOptions _context;

        public CourseRepository(IOptions<DBContextOptions> dbContextOptions, ApplicationDbContext context) 
        {
            _context = dbContextOptions.Value;
        }

        public ICollection<CourseResponse> GetAllCourses()
        {
            var listCoursesResponse = new List<CourseResponse>();
            try
            {
                var dBContext = _context.DBContext;                
                using (SqlConnection sqlCon = new SqlConnection(dBContext))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("GetAllCourses", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = sql_cmnd.ExecuteReader();
                    while (reader.Read())
                    {
                        var course = new CourseResponse
                        {
                            Id = Convert.ToInt32(reader["IdCourse"]),
                            Name = reader["CourseName"].ToString(),
                            IdMember = Convert.ToInt32(reader["IdMember"]),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"])
                        };
                        listCoursesResponse.Add(course);
                    }
                    reader.Close();
                    sqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            return listCoursesResponse;
        }

        public CourseResponse PostCourse(CourseRequest request)
        {
            var courseResponse = new CourseResponse();
            return courseResponse;
        }
    }
}
