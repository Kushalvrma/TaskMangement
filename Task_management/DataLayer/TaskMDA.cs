using MySql.Data.MySqlClient;
using System.Data;
using Task_management.Models;

namespace Task_management.DataLayer
{
    public class TaskMDA
    {
        private readonly IConfiguration _configuration;
        

        public TaskMDA(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public List<TaskM> TaskMGetDA()
        {
            List<TaskM> TaskMData = new List<TaskM>();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("servername"));
            {
                using (MySqlCommand cmd = new MySqlCommand("Sp_TaskMdisplay", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        TaskM task = new TaskM();
                        task.Task_id = Convert.ToInt32(reader["task_id"]);
                        task.User_id = Convert.ToInt32(reader["user_id"]);
                        task.Task_Name = Convert.ToString(reader["task_name"]);
                        task.Task_Status = Convert.ToBoolean(reader["task_status"]);
                       

                        TaskMData.Add(task);
                    }
                    con.Close();
                }
            }
            return TaskMData;

        }



        public TaskM TaskMPostDA(TaskM e )
        {
            TaskM er = new TaskM();
            MySqlConnection con = new MySqlConnection(_configuration.GetConnectionString("servername"));
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand("Sp_TaskMPost", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@_task_id", e.Task_id);
                    cmd.Parameters.AddWithValue("@_user_id", e.User_id);
                    cmd.Parameters.AddWithValue("@_task_name", e.Task_Name);
                    cmd.Parameters.AddWithValue("@_task_status", e.Task_Status);
                    
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
                return e;
            }

        }
        

    }
}
