using BooksProject.API.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BooksProject.API.repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> loginAsync(SignInModel signInModel);
    }
}
