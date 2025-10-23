using System;
using API.Entity;
using API.Helper;

namespace API.Interface;

public interface IMemberRepository
{
    Task<PaginatedResult<Member>> GetMembersAsync(MemberParams  pagingParams);
}
