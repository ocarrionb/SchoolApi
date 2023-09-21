using School.Domain.Requests.Members;
using School.Domain.Responses.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Service.Members
{
    public interface IMemberService
    {
        CreateMemberResponse PostMember (CreateMemberRequest request);
        GetMemberResponse GetMember(GetMemberByIdRequest request);
    }
}
