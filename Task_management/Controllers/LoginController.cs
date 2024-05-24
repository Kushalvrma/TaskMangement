using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_management.Models;
using Task_management.Services.Interface;
using Task_management.Services;

namespace Task_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin loginServices;
        private IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            loginServices = new LoginService(configuration);
        }


        [Route("Login")]
        [HttpPost]
        public Login LoginPost(LoginModel log)
        {
            Login login = new Login();
            login = loginServices.Login(log.email, log.password);
            return login;
        }
    }
}

