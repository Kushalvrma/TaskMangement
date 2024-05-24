using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_management.Models;
using Task_management.Services.Interface;
using Task_management.Services;

namespace Task_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskMController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITaskM task;

        public TaskMController(IConfiguration configuration)
        {
            _configuration = configuration;
            task = new TaskMService(configuration);
        }



        [HttpGet("TaskGetData")]
        public List<TaskM> TaskGet()
        {
            List<TaskM> taskuser = new List<TaskM>();
            taskuser = task.getTask();
            return taskuser;

        }


        [HttpPost("TaskPostData")]
        public TaskM TaskPost(TaskM e)
        {
            TaskM taskpost = new TaskM();
            taskpost = task.postTask(e);
            return taskpost;
        }


    }
}
