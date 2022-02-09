using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Models;
using Common;
using HiddenVilla_Api.Helper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace HiddenVilla_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly APISettings _aPISettings;

        public AccountController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<APISettings> options)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _aPISettings = options.Value;
        }

        [HttpPost]
        [AllowAnonymous] //ruší "Authorize"
        public async Task<IActionResult> SignUp([FromBody] UserRequestDTO userRequestDTO)
        {
            if (userRequestDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new ApplicationUser
            {
                UserName = userRequestDTO.Email,
                Email = userRequestDTO.Email,
                Name = userRequestDTO.Name,
                PhoneNumber = userRequestDTO.PhoneNo,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRequestDTO.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegisterationResponseDTO
                { Errors = errors, IsRegisterationSuccessful = false });
            }
            var roleResult = await _userManager.AddToRoleAsync(user, SD.Role_Customer);

            if (!roleResult.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegisterationResponseDTO
                { Errors = errors, IsRegisterationSuccessful = false });
            }
            return StatusCode(201);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] AuthenticationDTO authenticationDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(authenticationDTO.UserName, authenticationDTO.Password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(authenticationDTO.UserName);
                if (user == null)
                {
                    return Unauthorized(new AuthenticationResponseDTO
                    {
                        IsAuthSuccessful = false,
                        ErrorMessage = "Neplatné ověření"
                    });
                }
                //vše je platné a přihlásíme uživatele

                var signinCredentials = GetSigningCredentials();
                var claims = await GetClaims(user);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _aPISettings.ValidIssuer,
                    audience: _aPISettings.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new AuthenticationResponseDTO
                {
                    IsAuthSuccessful = true,
                    Token = token,
                    userDTO = new UserDTO
                    {
                        Name = user.Name,
                        Id = user.Id,
                        Email = user.Email,
                        PhoneNo = user.PhoneNumber
                    }
                });
            }
            else
            {
                return Unauthorized(new AuthenticationResponseDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Neplatné ověření"
                });                
            }           
        }






        //dvě pomocné metody 
        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_aPISettings.SecretKey));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Id", user.Id),
            };
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
    }
}
