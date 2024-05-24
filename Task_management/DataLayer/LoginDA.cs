using MySql.Data.MySqlClient;
using System.Data;
using Task_management.Models;

namespace Task_management.DataLayer
{
    public class LoginDA
    {
        private readonly IConfiguration _configuration;


        public LoginDA(IConfiguration configuration)
        {
            _configuration = configuration;
        }


         public Login Login(string? email,string? password)
        {
            Login data = new Login();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("servername"));            
                MySqlCommand cmd = new MySqlCommand("Sp_LoginPost", con);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_email", email);
                cmd.Parameters.AddWithValue("@_password", password);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    data.id = Convert.ToInt32(reader["id"]);
                    data.name = Convert.ToString(reader["name"]);
                    data.password = Convert.ToString(reader["password"]);
                    data.email = Convert.ToString(reader["email"]);
                    data.roleId = Convert.ToInt32(reader["roleId"]);
                    data.phonenumber = Convert.ToString(reader["phonenumber"]);
                }
            con.Close();            
            return data;
        }
    }
}

