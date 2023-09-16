namespace DatabaseUserItem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Salary_range { get; set; }
        public string? Employee_type { get; set; }
        public DateTime?  BirthDate { get; set; }
        public int PositionId { get; set; }


    }
}
