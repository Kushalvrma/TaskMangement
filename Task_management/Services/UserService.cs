using Task_management.DataLayer;
using Task_management.Models;
using Task_management.Services.Interface;

namespace Task_management.Services
{
    public class UserService: IUser
    {
        private readonly IConfiguration _configuration;
        private readonly UserDA userDA;
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
            userDA = new UserDA(configuration);
        }



        public List<AddUser> getallUser()
        {
            List<AddUser> users = new List<AddUser>();
            users = userDA.GetAllUserDA();
            return users;
        }

        public AddUser postUser(AddUser e)
        {
           AddUser users = new AddUser();
            users = userDA.PostUserDA(e);
            return users;
        }

        public AddUser editgetUser(int id)
        {
            AddUser users = new AddUser();
            users = userDA.EditDA(id);
            return users;
        }
        public EditUser editUser(EditUser e, int id)
        {
            EditUser users = new EditUser();
            users = userDA.EditUserDA(e, id);
            return users;
        }

        public void deleteUser( int id)
        {
            userDA.DeleteUserDA(id);
        }


    }
}
