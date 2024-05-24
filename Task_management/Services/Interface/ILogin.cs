using Task_management.Models;

namespace Task_management.Services.Interface
{
    public interface ILogin 
    {        
            public Login Login(string? email, string? password);
       
    }
}
