using Microsoft.AspNetCore.Mvc;
using Task_management.Models;
using Task_management.Services.Interface;
using Task_management.Services;

namespace Task_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUser user;


        public AddUserController(IConfiguration configuration)
        {
            _configuration = configuration;
            user = new UserService(configuration);
        }

        [HttpGet("GetData")]
        public List<AddUser> GetAllUser()
        {
            List<AddUser> userget= new List<AddUser>();
            userget = user.getallUser();
            return userget;
        }

        [HttpPost("Postuser")]
        public AddUser PostUser(AddUser e) 
        {
            AddUser userpost = new AddUser();
            userpost = user.postUser(e);
            return userpost;
        }


        [HttpGet("EditGetDatabyid")]
        public AddUser EditGetUser(int id)
        {
           AddUser edituserget = new AddUser();
            edituserget = user.editgetUser(id);
            return edituserget;
        }

        [HttpPost("EdituserById")]
        public EditUser EditUser(int id, EditUser e)
        {
            EditUser userput = new EditUser();
            userput = user.editUser(e, id);
            return userput;
        }

        [HttpGet("DeleteuserById")] 
        public int DeleteUser(int id)
        {
            user.deleteUser(id);
            return id;
        }

    }
}
