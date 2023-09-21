using School.Domain.Requests.Members;
using School.Domain.Responses.Members;
using School.Repository.Members;
using XSystem.Security.Cryptography;

namespace School.Service.Members
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public CreateMemberResponse PostMember(CreateMemberRequest request)
        {
            var passwordEncriptado = GetMd5(request.Password);
            request.Password = passwordEncriptado;
            var memberResponse = _memberRepository.PostMember(request);
            return memberResponse;
        }

        public GetMemberResponse GetMember(GetMemberByIdRequest request)
            => _memberRepository.GetMember(request);

        private static string GetMd5(string pass)
        {
            MD5CryptoServiceProvider tmp = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(pass);
            data = tmp.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;
        }
    }
}
