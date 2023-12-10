using System.ComponentModel.DataAnnotations;

namespace SaggiWebConsume.Models
{
    public class RoleView
    {
        /*public RoleView()
        {
            Users = new HashSet<User>();
        }*/
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        //[Column(TypeName = "nvarchar(25)")]

        public string RoleName { get; set; }
        //public virtual ICollection<User> Users { get; set; }
    }
}
