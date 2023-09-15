using System.Reflection.Metadata;

namespace DatabaseUserItem.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        public string? Secret { get; set; }

        public int UserId { get; set; }
        //public virtual User User { get; set; } 
    }
}
