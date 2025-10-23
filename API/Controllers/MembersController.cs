using API.Entity;
using API.Helper;
using API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Controller responsible for managing member-related operations
    /// Handles CRUD operations and pagination for member data
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController (IMemberRepository memberRepository): ControllerBase
    {
        /// <summary>
        /// Retrieves a paginated list of members with optional filtering
        /// </summary>
        /// <param name="memberParams">Query parameters for filtering and pagination</param>
        /// <returns>Returns a paginated list of members</returns>
        [HttpGet]
        public async Task<ActionResult<ActionResult<IReadOnlyList<Member>>>> GetMembersAsync([FromQuery] MemberParams memberParams)
        {
            var members = await memberRepository.GetMembersAsync(memberParams);
            return Ok(members);
        }
    }
}
