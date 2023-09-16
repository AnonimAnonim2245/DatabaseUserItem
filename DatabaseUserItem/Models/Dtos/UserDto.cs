namespace DatabaseUserItem.Models.Dtos
{
    public class UserDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string? Email { get; set; }
        public string? Salary { get; set; }
        public string? Employee_type { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}
