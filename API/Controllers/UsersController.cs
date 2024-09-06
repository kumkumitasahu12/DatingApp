using System.Security.Claims;
using API.Data;
using API.DTOS;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController(IUserRepository userRepository, IMapper mapper) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await userRepository.GetMembersAsync();
            return Ok(users);
        }       

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var user = await userRepository.GetMemberAsync(username);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier);

            if(username == null)
            {
                return BadRequest();
            }

            var user = await userRepository.GetUserByUsernameAsync(username.Value);

            if(user == null)
            {
                return BadRequest();
            }

            mapper.Map(memberUpdateDto, user);

            if (await userRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to updated");
        }
    }
}
