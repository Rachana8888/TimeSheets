using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaggiTimeSheet.Models
{
    
    public class Project
    {
        public Project()
        {
            TimeSheetEntries = new HashSet<TimeSheetEntry>();
        }
        [Key]
        public int ProjectId { get; set; }

        //Column(TypeName = "nvarchar(50)")]
        public string ProjectName { get; set; }
        //[Column(TypeName = "nvarchar(20)")]

        public string ProjectCode { get; set; }
        [ForeignKey("UserId")]
        public int ProjectManagerId { get; set; }
        public virtual User? Users { get; set; }
        public virtual ICollection<TimeSheetEntry> TimeSheetEntries { get; set; }


    }
}
