using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaggiTimeSheet.Models
{
    
    public class TimeSheet
    {
        public TimeSheet()
        {
            Approvals = new HashSet<Approval>();
            TimeSheetEntries = new HashSet<TimeSheetEntry>();
        }
        [Key]
        public int TimeSheetId { get; set; }
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public virtual User Users { get; set; }
        public DateTime WeekStarting { get; set; } 
        public int TotalHours { get; set; }
        public DateTime SubmissionDate { get; set; } =DateTime.Now;
        //[Column(TypeName = "nvarchar(20)")]
        public string ApprovalStatus { get; set; }
        public virtual ICollection<Approval> Approvals { get; set; }
        public virtual ICollection<TimeSheetEntry> TimeSheetEntries { get; set; }





    }
}
