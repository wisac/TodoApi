using Microsoft.AspNetCore.Mvc;
using TodoApi.Dtos.Users;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
   private readonly IUserService _service;

   public UserController(IUserService userService)
   {
      _service = userService;
   }

   // GET: TodoController
   [HttpPost("register")]
   public async Task<IActionResult> Create(UserCreateDto user)
   {
      var newUser = await _service.CreateUser(user);

      return Created($"api/users/{newUser.Id}", newUser);
   }

   [HttpGet("{id}")]
   public async Task<IActionResult> GetUserById(int id)
   {
      var user = await _service.GetUserById(id);
      if (user == null)
      {
         return NotFound();
      }
      return Ok(user);
   }
}
