using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaggiTimeSheet.Models
{
   
    public class TimeSheetEntry
    {
        [Key]
        public int TimeSheetEntryId { get; set; }
        [ForeignKey("TimeSheetId")]
        public int TimeSheetId { get; set; }
        public virtual TimeSheet? TimeSheets { get; set; }

        [ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
        public virtual Project? Projects { get; set; }
      
        public DateTime Date {  get; set; }
        
        public int HoursWorked { get; set; }
       

    }
}
