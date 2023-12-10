using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaggiTimeSheet.Models
{
  
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        //[Column(TypeName = "nvarchar(25)")]
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }


    }
}
