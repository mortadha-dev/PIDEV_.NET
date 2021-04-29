using ConsumeWebServices.Models;

namespace ConsumeWebServices.Models
{
    public class Role
    {
        public int idRole { get; set; }
        public string description { get; set; }
        public RoleType roleType { get; set; }
     //   public virtual Set<User> user { get; set; }

    }
}