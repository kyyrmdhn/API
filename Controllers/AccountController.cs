using Api.Repositories.Data;
using Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountRepository accountRepository;
        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository; 
        }
        [HttpGet]
        public ActionResult Login(string email, string password)
        {
            try
            {
                var data = accountRepository.Login(email, password);
                if (data != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Berhasil Login!",
                        Data = data
                    });
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

        [HttpPost]
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
                if (result != null)
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

        [HttpPut("ForgorPassword/")]
        public ActionResult ForgotPassword(ForgotPasswordVM forgotPasswordVM)
        {
            try
            {
                var result = accountRepository.ForgotPassword(forgotPasswordVM);
                if (result != null)
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
