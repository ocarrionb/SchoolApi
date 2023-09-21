using School.Domain.Enumerables;

namespace School.Domain.Requests.Members
{
    public sealed class CreateMemberRequest
    {
        public required string MemberName { get; set; }        
        public required string MemberLastName { get; set; }        
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public MemberTypeEnum MemberType { get; set; }
        public bool IsActive { get; set; }
    }
}
