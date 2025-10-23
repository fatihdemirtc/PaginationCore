using System;
using API.Entity;
using API.Helper;

namespace API.Interface;

/// <summary>
/// Repository interface for member-related data operations
/// </summary>
public interface IMemberRepository
{
    /// <summary>
    /// Retrieves a paginated list of members based on the provided parameters
    /// </summary>
    /// <param name="pagingParams">Parameters for filtering and pagination</param>
    /// <returns>A paginated result containing members matching the criteria</returns>
    Task<PaginatedResult<Member>> GetMembersAsync(MemberParams pagingParams);
}
