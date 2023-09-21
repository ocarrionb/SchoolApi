using AutoMapper;
using School.Domain.Requests.Members;
using School.Domain.Responses.Members;

namespace School.Domain.AutoMapper
{
    public class MemberMapper : Profile
    {
        public MemberMapper()
        {
            CreateMap<CreateMemberResponse, CreateMemberRequest>().ReverseMap();
        }        
    }
}
