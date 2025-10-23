using API.Entity;
using API.Helper;
using API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController (IMemberRepository memberRepository): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ActionResult<IReadOnlyList<Member>>>> GetMembersAsync([FromQuery] MemberParams memberParams)
        {
            var members = await memberRepository.GetMembersAsync(memberParams);
            return Ok(members);
        }
    }
}
