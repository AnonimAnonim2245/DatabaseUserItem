namespace DatabaseUserItem.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Manager { get; set; }

        public string? Description { get; set; }

        public virtual List<Position> Positions { get; set; }

    }
}
