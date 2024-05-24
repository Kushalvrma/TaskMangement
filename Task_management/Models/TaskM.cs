using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_management.Models
{
    public class TaskM
    {
        [Key]
        public int Task_id { get; set; }

        public int User_id { get; set; }

        public string Task_Name { get; set; }

        public bool Task_Status { get; set; }

    }


    
}
