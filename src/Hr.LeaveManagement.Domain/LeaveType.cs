using Hr.LeaveManagement.Domain.Common;

namespace Hr.LeaveManagement.Domain
{
    public class LeaveType:BaseEntity
    {        
        public string Name { get; set; } = string.Empty;  
        public int DefaultDays { get; set; }
    }
}
