using System;
using API.Entity;
using API.Helper;
using API.Interface;

namespace API.Data;

/// <summary>
/// Repository implementation for member-related data operations
/// </summary>
public class MemberRepository(AppDbContext context) : IMemberRepository
{
    /// <summary>
    /// Retrieves a paginated list of members with filtering options
    /// - Excludes current member from results
    /// - Filters by gender if specified
    /// - Filters by age range
    /// - Orders by created date or last active date
    /// </summary>
    /// <param name="memberParams">Parameters for filtering and pagination</param>
    /// <returns>A paginated result of filtered members</returns>
    public async Task<PaginatedResult<Member>> GetMembersAsync(MemberParams memberParams)
    {
        var query = context.Members.AsQueryable();
        query = query.Where(x => x.Id != memberParams.CurrentMemberId);

        if (memberParams.Gender != null)
        {
            query = query.Where(x => x.Gender == memberParams.Gender);
        }

        var minDob = DateOnly.FromDateTime(DateTime.Today.AddYears(-memberParams.MaxAge - 1));
        var maxDob = DateOnly.FromDateTime(DateTime.Today.AddYears(-memberParams.MinAge));

        query = query.Where(x => x.DateOfBirth >= minDob && x.DateOfBirth <= maxDob);

        query = memberParams.OrderBy switch
        {
            "created" => query.OrderByDescending(x => x.Created),
            _ => query.OrderByDescending(x => x.LastActive)
        };
        return await PaginationHelper.CreateAsync(query, memberParams.PageNumber, memberParams.PageSize);
    }

}
