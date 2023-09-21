namespace School.Domain.Responses.Course
{
    public sealed class CourseResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int IdMember { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
