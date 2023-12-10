using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaggiTimeSheet.Models
{
 
    public class Approval
    {
        [Key]
        public int ApprovalId { get; set; }
        [ForeignKey("TimeSheetId")]
        public int? TimeSheetId { get; set; }
        public virtual TimeSheet? TimeSheets { get; set; }

        [ForeignKey("UserId")]
        public int ApproverUserId { get; set; }
        public virtual User? Users { get; set; }
        public DateTime? ApprovalDate { get; set; }
        //[Column(TypeName = "nvarchar(15)")]
        public string? ApprovalStatus { get; set; }
       


    }
}
