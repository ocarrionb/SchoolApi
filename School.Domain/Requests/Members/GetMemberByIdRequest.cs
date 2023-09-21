using System.ComponentModel.DataAnnotations;

namespace School.Domain.Requests.Members
{
    public class GetMemberByIdRequest
    {
        [Required]
        public int MemberId { get; set; }
    }
}
