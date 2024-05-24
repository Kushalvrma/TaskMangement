using Task_management.DataLayer;
using Task_management.Models;
using Task_management.Services.Interface;

namespace Task_management.Services
{
    public class LoginService : ILogin
    {
        private readonly IConfiguration _configuration;
        private readonly LoginDA loginDA;
        public LoginService(IConfiguration configuration)
        {
            _configuration = configuration;
            loginDA = new LoginDA(configuration);
        }
        

        public Login Login(string? email, string? password)
        {
            Login login = new Login();
            login = loginDA.Login(email, password);
            return login;
        }

    }
}
