using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Account;
using api.Interfacses;
using api.Models;
using api.services;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

namespace api.Controllers

{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenSerice;
        private readonly SignInManager<AppUser> _singInManager;

        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenSerice = tokenService;
            _singInManager = signInManager;
        }

        [HttpPost("register")]

        public async Task<IActionResult> CreateAsync([FromBody] RegisterDto registerDto)
        {
            try
            {
                // Corrected condition to check if ModelState is NOT valid
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                // Removed the curly braces after CreateAsync
                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDto
                            {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = _tokenSerice.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpPost]

        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            if (user == null)
            {
                return Unauthorized("UserName Not Found");

            }

            var result = await _singInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);


            if (!result.Succeeded)
            {
                return Unauthorized("Username or Password is inccroect");
            }

            return Ok(

                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenSerice.CreateToken(user)
                }
            );




        }
    }
}
