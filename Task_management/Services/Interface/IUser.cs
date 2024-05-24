using Task_management.DataLayer;
using Task_management.Models;

namespace Task_management.Services.Interface
{
    public interface IUser
    {
        public List<AddUser> getallUser();
        public AddUser postUser(AddUser e);
        public AddUser editgetUser(int id);
        public EditUser editUser(EditUser e,int id);
        public void deleteUser(int id);
       
    }

   
}
