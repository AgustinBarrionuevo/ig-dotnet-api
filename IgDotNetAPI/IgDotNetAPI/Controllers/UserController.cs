using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IgDotNetAPI.DTOs;
using IgDotNetAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IgDotNetAPI.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserManager<Person> UserManager { get; }
        public SignInManager<Person> SignInManager { get; }
        public ILogger<UserController> Logger { get; }

        public UserController(UserManager<Person> userManager, SignInManager<Person> signInManager, ILogger<UserController> logger)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            Logger = logger;
        }

        // GET api/<UserController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Read(string id)
        {
            Logger.LogInformation(message: "Getting user by id", id);
            var user = await UserManager.FindByIdAsync(id);
            if (user != null) return Ok(user);
            return BadRequest("Failed to get user");
        }

        // POST api/<UserController>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonCreateDto person)
        {
            Logger.LogInformation(message: "Registering new user", person);
            var result = await UserManager.CreateAsync(person.GetPerson(), person.Password);
            if (result.Succeeded) return Ok(result);
            return BadRequest(result);
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonUpdateDto person) {
            Logger.LogInformation(message: "Updating user", person);

            var user = await UserManager.GetUserAsync(User);
            var result = await UserManager.UpdateAsync(person.UpdatePerson(user));
            if (result.Succeeded) return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            Logger.LogInformation(message: "Deleting user", id);
            var result = await UserManager.DeleteAsync(await UserManager.FindByIdAsync(id));
            if (result.Succeeded) return Ok(result);
            return BadRequest(result);
        }
    }
}
