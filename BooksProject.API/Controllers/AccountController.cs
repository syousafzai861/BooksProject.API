using BooksProject.API.Models;
using BooksProject.API.repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;

namespace BooksProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUpMethod([FromBody]SignUpModel signUpModel)
        {
            var result = await _accountRepository.SignUpAsync(signUpModel);

            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return null;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginMethod([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepository.loginAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return null;
            }

            return Ok(result);
           
        }


    }
}
