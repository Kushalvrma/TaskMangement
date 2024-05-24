namespace Task_management.Models
{
    public class AddUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string Phonenumber { get; set; }
        public int? CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int Is_Deleted { get; set; }
        public int RoleId { get; set; }
        public int IsActive { get; set; }

    }

}
