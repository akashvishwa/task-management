using Microsoft.AspNetCore.Mvc;
using TaskManagement.Dto;
using TaskManagement.Interfaces;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : SuperController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("UpsertUser")]
        public async Task<IActionResult> UpsertUser(UserDto data) 
        {
            var result=await userService.UpsertUser(data);
            return Ok(result);        
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await userService.GetAllUser();
            return Ok(result);
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(Guid Id)
        {
            var result = await userService.GetUserById(Id);
            return Ok(result);
        }


    }
}
