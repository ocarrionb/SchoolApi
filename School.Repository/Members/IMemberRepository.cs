using School.Domain.Requests.Members;
using School.Domain.Responses.Members;

namespace School.Repository.Members
{
    public interface IMemberRepository
    {
        CreateMemberResponse PostMember(CreateMemberRequest request);
        GetMemberResponse GetMember(GetMemberByIdRequest request);
    }
}
