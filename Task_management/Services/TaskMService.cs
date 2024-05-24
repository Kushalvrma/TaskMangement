using Task_management.DataLayer;
using Task_management.Services.Interface;
using Task_management.Models;

namespace Task_management.Services
{
    public class TaskMService : ITaskM
    {
        private readonly IConfiguration _configuration;
        private readonly TaskMDA taskmDA;
        public TaskMService(IConfiguration configuration)
        {
            _configuration = configuration;
            taskmDA = new TaskMDA(configuration);
        }

        public List<TaskM> getTask()
        {
            List<TaskM> registrations = new List<TaskM>();
            registrations = taskmDA.TaskMGetDA();
            return registrations;
        }


        public TaskM postTask(TaskM e)
        {
            TaskM registrations = new TaskM();
            registrations = taskmDA.TaskMPostDA(e);
            return registrations;
        }
               
    }
}