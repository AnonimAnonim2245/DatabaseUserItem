using System.Reflection.Metadata;

namespace DatabaseUserItem.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Position_name { get; set; }
        
        public string? Secret { get; set; }
        public int CompanyId { get; set; }
        public virtual List<User> Users { get; set; }


        //public virtual User User { get; set; } 
    }
}
