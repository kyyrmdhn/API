using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Repositories.Data;
using Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountRepository accountRepository;
        public IConfiguration configuration;
        public AccountController(IConfiguration configuration, AccountRepository accountRepository)
        {
            this.configuration = configuration;
            this.accountRepository = accountRepository; 
        }
        //[HttpGet]
        [HttpPost("Login")]
        public ActionResult Login(string email, string password)
        {
            try
            {
                var data = accountRepository.Login(email, password);
                if (data != null)
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                    new Claim("Id", data.Id.ToString()),
                    new Claim("FullName", data.FullName),
                    new Claim("Email", data.Email),
                    new Claim("role", data.Role)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        configuration["Jwt:Issuer"],
                        configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signIn);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login Gagal!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVM)
        {
            try
            {
                var result = accountRepository.Register(registerVM);
                if (result != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Berhasil melakukan register!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Gagal melakukan register!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPut("ChangePassword")]
        public ActionResult ChangePassword(ChangePasswordVM changePasswordVM)
        {
            try
            {
                var result = accountRepository.ChangePassword(changePasswordVM);
                if (result > 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Berhasil mengganti password!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Gagal mengganti password!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }

        [HttpPut("ForgotPassword/")]
        public ActionResult ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            try
            {
                var result = accountRepository.ForgotPassword(forgotPasswordVM);
                if (result > 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Berhasil mengubah password!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Gagal mengubah Password!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }
}
