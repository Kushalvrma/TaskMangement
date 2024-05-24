using Task_management.Models;

namespace Task_management.Services.Interface
{
    public interface ITaskM
    {
        public List<TaskM> getTask();
        public TaskM postTask(TaskM e);

    }
}
