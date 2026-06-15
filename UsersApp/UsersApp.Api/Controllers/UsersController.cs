using Microsoft.AspNetCore.Mvc;
using UsersApp.Api.Models;
using UsersApp.Api.Services;

namespace UsersApp.Api.Controllers;

[ApiController]
[Route("[controller]")] // Route tu dong = /Users (ten class bo chu "Controller")
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }

    // GET /users
    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _usersService.GetUsers();
        return Ok(users); // HTTP 200 + JSON
    }

    // GET /users/{id}
    [HttpGet("{id}")]
    public IActionResult GetUserById(long id)
    {
        try
        {
            var user = _usersService.GetUserById(id);
            return Ok(user); // HTTP 200
        }
        catch (KeyNotFoundException)
        {
            return NotFound(); // HTTP 404
        }
    }

    // POST /users
    [HttpPost]
    public IActionResult AddUser([FromBody] User user)
    {
        try
        {
            var saved = _usersService.AddUser(user);
            // HTTP 201 + Location header tro den GET /users/{id}
            return CreatedAtAction(nameof(GetUserById), new { id = saved.Id }, saved);
        }
        catch (ArgumentException)
        {
            return BadRequest("Name cannot be empty"); // HTTP 400
        }
    }
}