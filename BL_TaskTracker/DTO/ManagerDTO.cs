using System.Collections.Generic;

namespace BLL_TaskTracker.DTO
{
    public class ManagerViewModel : EmployeeDTO
    {
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }

    }
}