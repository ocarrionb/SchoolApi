using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using School.Domain.Enumerables;
using School.Domain.Options;
using School.Domain.Requests.Members;
using School.Domain.Responses.Course;
using School.Domain.Responses.Members;
using System.Data;


namespace School.Repository.Members
{
    public sealed class MemberRepository : IMemberRepository
    {
        private readonly DBContextOptions _context;
        private readonly IMapper _mapper;

        public MemberRepository(IOptions<DBContextOptions> context, IMapper mapper) 
        {
            _context = context.Value;
            _mapper = mapper;
        }

        public GetMemberResponse GetMember(GetMemberByIdRequest request)
        {
            var memberResponse = new GetMemberResponse();
            try
            {
                var dBContext = _context.DBContext;
                using (SqlConnection sqlCon = new SqlConnection(dBContext))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("GetMember", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@MemberId", SqlDbType.VarChar).Value = request.MemberId;

                    SqlDataReader reader = sql_cmnd.ExecuteReader();
                    while (reader.Read())
                    {
                        memberResponse.MemberId = Convert.ToInt32(reader["MemberId"]);
                        memberResponse.MemberName = reader["MemberName"].ToString();
                        memberResponse.MemberLastName = reader["MemberLastName"].ToString();
                        memberResponse.UserName = reader["UserName"].ToString();
                        memberResponse.Email = reader["Email"].ToString();
                        memberResponse.MemberType = (MemberTypeEnum)reader["MemberType"];
                        memberResponse.IsActive = Convert.ToInt32(reader["IsActive"]) == 1;
                        memberResponse.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                    }
                    reader.Close();
                    sqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            return memberResponse;
        }
        
        public CreateMemberResponse PostMember(CreateMemberRequest request)
        {
            var memberResponse = _mapper.Map<CreateMemberResponse>(request);
            try
            {
                var dBContext = _context.DBContext;
                using (SqlConnection sqlCon = new SqlConnection(dBContext))
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("PostMember", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;

                    sql_cmnd.Parameters.AddWithValue("@MemberName", SqlDbType.VarChar).Value = request.MemberName;
                    sql_cmnd.Parameters.AddWithValue("@MemberLastName", SqlDbType.VarChar).Value = request.MemberLastName;
                    sql_cmnd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = request.UserName;
                    sql_cmnd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = request.Password;
                    sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = request.Email;
                    sql_cmnd.Parameters.AddWithValue("@MemberType", SqlDbType.Int).Value = (int)request.MemberType;
                    sql_cmnd.Parameters.AddWithValue("@IsActive", SqlDbType.Bit).Value = request.IsActive;

                    SqlDataReader reader = sql_cmnd.ExecuteReader();
                    while (reader.Read())
                    {
                        memberResponse.MemberId = Convert.ToInt32(reader["MemberId"]);
                    }
                    memberResponse.CreatedDate = DateTime.Now;
                    
                    reader.Close();                    
                    sqlCon.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
            }
            return memberResponse;
        }
    }
}
