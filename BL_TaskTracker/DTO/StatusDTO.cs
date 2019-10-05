using System.Collections.Generic;

namespace BLL_TaskTracker.DTO
{
    public class StatusDTO
    {
        public int StatusId { get; set; }
        public string Message { get; set; }
        public bool IsCompleted { get; set; }

    }
}