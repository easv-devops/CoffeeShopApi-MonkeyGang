using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;
using Models.DTOs.Create;
using Models.DTOs.Response;
using Models.Utility;
using Service;

namespace Presentation.Controllers;

using System;
using System.Collections.Generic;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(IMapper mapper ,IUserService userService)
    {
        _mapper = mapper;   
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    [HttpGet("{userId}")] // This route should match the route used in CreatedAtAction
    public async Task<IActionResult> GetUser(Guid userId)
    {
        try
        {
            // Retrieve the user by ID using the service
            var user = await _userService.GetUserAsync(userId);

            // Check if the user exists
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Map the user to the response DTO using AutoMapper
            var responseDto = _mapper.Map<UserResponseDto>(user);

            // Return the user response
            return Ok(responseDto);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return BadRequest("Failed to retrieve user.");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAllUsers()
    {
        try
        {
            var usersDto = await _userService.GetAllUsersAsync();
            return Ok(usersDto);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return StatusCode(500, "Internal Server Error");
        }
    }


    [HttpPost("add")]
    public async Task<IActionResult> AddUser([FromBody] CreateUserDTO createUserDto)
    {
        try
        {
            // Map CreateUserDto to User entity using AutoMapper
            var user = _mapper.Map<User>(createUserDto);

            // Add user to the database and get the generated ID
            await _userService.AddUserAsync(user);

            Guid generatedId = user.UserId;
            
            // Map the created user to a response DTO using AutoMapper
            var responseDto = _mapper.Map<UserResponseDto>(user);
            responseDto.UserId = generatedId;

            // Return the created user response
            return CreatedAtAction(nameof(GetUser), new { userId = generatedId }, responseDto);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return BadRequest("Failed to create user.");
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UserDto userDto)
    {
        try
        {
            if (id != userDto.UserId)
            {
                return BadRequest("Mismatched user ID");
            }

            await _userService.UpdateUserAsync(userDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(Guid id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return StatusCode(500, "Internal Server Error");
        }
    }
    
    
    [HttpPost("verify-password")]
    public IActionResult VerifyPassword([FromBody] PasswordVerificationRequest request)
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Email and password are required.");
        }

        bool isCorrectPassword = _userService.VerifyPasswordAsync(request.Email, request.Password);

        if (isCorrectPassword)
        {
            return Ok("Password is correct.");
        }
        else
        {
            return Unauthorized("Invalid email or password.");
        }
    }
    
    
    //retrive user by email
    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        try
        {
            // Retrieve the user by ID using the service
            var user = await _userService.GetUserByEmailAsync(email);

            // Check if the user exists
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Map the user to the response DTO using AutoMapper
            var responseDto = _mapper.Map<UserResponseDto>(user);

            // Return the user response
            return Ok(responseDto);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return BadRequest("Failed to retrieve user.");
        }
    }

    
    
    
}