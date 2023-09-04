namespace Test.Data.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastname { get; set; }
        public DateTime PermissionDate { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
