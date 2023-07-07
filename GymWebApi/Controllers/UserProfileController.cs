using GymWebApi.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GymWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserProfileController(UserManager<IdentityUser> userManager, IUserStore<IdentityUser> userStore, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IResult> CreateUser([FromBody] JsonElement userCredentials)
        {
            var email = userCredentials.GetProperty("email").GetString();
            var password = userCredentials.GetProperty("password").GetString();

            var registerModel = new RegisterModel(_userManager, _userStore, _signInManager)
            {
                Input = new RegisterModel.InputModel
                {
                    Email = email,
                    Password = password
                }
            };
            var res = await registerModel.OnPostAsync();
            Console.WriteLine(res);
            return res ;
        }
    }
}
