﻿using School.Domain.Enumerables;

namespace School.Domain.Responses.Members
{
    public sealed class CreateMemberResponse
    {
        public int MemberId { get; set; }
        public string? MemberName { get; set; }
        public MemberTypeEnum MemberType { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
