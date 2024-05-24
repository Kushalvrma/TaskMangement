using MySql.Data.MySqlClient;
using System.Data;
using Task_management.Models;
using Task_management.PasswordGenerator;

namespace Task_management.DataLayer
{
    public class UserDA
    {
        private readonly IConfiguration _configuration;
        public UserDA(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<AddUser> GetAllUserDA()
        {
            List<AddUser> UserData = new List<AddUser>();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("servername"));
            {
                using (MySqlCommand cmd = new MySqlCommand("Sp_Display", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AddUser model = new AddUser();
                        model.Id = Convert.ToInt32(reader["id"]);
                        model.Name = Convert.ToString(reader["name"]);
                        model.Password = Convert.ToString(reader["password"]);
                        model.Email = Convert.ToString(reader["email"]);
                        model.Phonenumber = Convert.ToString(reader["phonenumber"]);
                        model.CreatedBy = Convert.ToInt32(reader["createdBy"]);
                        model.ModifiedBy = Convert.ToInt32(reader["modifiedBy"]);
                        model.CreatedOn = Convert.ToDateTime(reader["createdOn"]);
                        model.ModifiedOn = Convert.ToDateTime(reader["modifiedOn"]);
                        model.Is_Deleted = Convert.ToInt32(reader["is_deleted"]);
                        model.RoleId = Convert.ToInt32(reader["roleId"]);
                        model.IsActive = Convert.ToInt32(reader["is_Active"]);

                        UserData.Add(model);
                    }
                    con.Close();
                }
            }
            return UserData;

        }




        public AddUser PostUserDA(AddUser e )
        {
            string password;
            RandomPasswordGenerator randomPasswordGenerator = new RandomPasswordGenerator();
            AddUser er = new AddUser();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("servername"));
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("Sp_Post_procedure", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_id", e.Id);
                        cmd.Parameters.AddWithValue("@_name", e.Name);
                        cmd.Parameters.AddWithValue("@_password", randomPasswordGenerator.GeneratePassword(true,true,true,true,12));
                        cmd.Parameters.AddWithValue("@_email", e.Email);
                        cmd.Parameters.AddWithValue("@_roleId", e.RoleId);
                        cmd.Parameters.AddWithValue("@_phonenumber", e.Phonenumber);
                        
                        cmd.ExecuteNonQuery();

                        con.Close();
                    }
                return e;
            }

        }

        public AddUser EditDA(int id)
        {
            AddUser UserData = new AddUser();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("servername"));
            {
                using (MySqlCommand cmd = new MySqlCommand("Sp_EditGetDisplay", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_id", id);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UserData.Id = Convert.ToInt32(reader["id"]);
                        UserData.Name = Convert.ToString(reader["name"]);
                        UserData.Password = Convert.ToString(reader["password"]);
                        UserData.Phonenumber = Convert.ToString(reader["phonenumber"]);
                        
                    }
                    con.Close();
                }
            }
            return UserData;

        }
        public EditUser EditUserDA(EditUser e, int id)
        {
            EditUser er = new EditUser();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("servername"));
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("Sp_Put_procedure", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_id", id);
                    cmd.Parameters.AddWithValue("@_name", e.Name);
                    cmd.Parameters.AddWithValue("@_password", e.Password);
                    cmd.Parameters.AddWithValue("@_phonenumber", e.Phonenumber);
                   
                    cmd.ExecuteNonQuery(); 
                con.Close();
                }
                return e;
            }
        }



        public void DeleteUserDA(int id)
        {
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("servername"));
            {
                con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("Sp_Del_procedure", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_id", id);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }                    
                }           
        }        
    }
}
