using Hr.LeaveManagement.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Hr.LeaveManagement.Domain
{
    public class LeaveType:BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;  
        public int DefaultDays { get; set; }
    }
}
