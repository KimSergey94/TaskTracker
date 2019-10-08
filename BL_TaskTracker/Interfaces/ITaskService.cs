using BLL_TaskTracker.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_TaskTracker.Interfaces
{
    public interface ITaskService
    {
        void CreateTask(TaskDTO taskDTO);
        //int GetManagerId(TaskDTO taskDTO);


        List<UserDTO> GetUsers();//
        List<AdminDTO> GetAdmins();//
        List<ClientDTO> GetClients();//

        List<EmployeeDTO> GetEmployees();//
        List<ManagerDTO> GetManagers();//

        List<TaskDTO> GetTasks();//
        List<StatusDTO> GetStatusReports();
        List<CommentDTO> GetComments();
        List<RoleDTO> GetRoles();
        void Dispose();
    }
}
