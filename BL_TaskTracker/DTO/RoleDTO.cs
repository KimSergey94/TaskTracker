using BLL_TaskTracker.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_TaskTracker.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual UserDTO UserDTO { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RoleDTO> Roles { get; set; }
    }
}
