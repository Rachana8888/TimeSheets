using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaggiTimeSheet.Models
{
    
    public class User
    {
        public User()
        {
            Approvals = new HashSet<Approval>();
            Projects = new HashSet<Project>();
            TimeSheets = new HashSet<TimeSheet>();
        }
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        //[Column(TypeName = "nvarchar(50)")]
       
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage ="Enter valid mail address")]

        //[Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }


        [ForeignKey("RoleId")]

        public int RoleId { get; set; }
        
        public virtual Role? Roles { get; set; }
        public virtual ICollection<Approval> Approvals { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<TimeSheet> TimeSheets { get; set; }


    }
}
