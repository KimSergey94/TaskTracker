using BL_TaskTracker.DTO;
using BLL_TaskTracker.DTO;
using DAL_TaskTracker.Entities;
using System.Collections.Generic;
using Task = DAL_TaskTracker.Entities.Task;

namespace BL_TaskTracker.Interfaces
{
    public interface IOrderService
    {
        void CreateTask(TaskDTO taskDTO);
        void AddTask(TaskDTO taskDTO);
        void AddEmployee(EmployeeDTO employeeDTO);
        void AddManager(ManagerDTO ManagerDTO);
        void AddAdmin(AdminDTO adminDTO);
        void AddUser(UserDTO userDTO);
        void AddClient(ClientDTO clientDTO);

        string GetUserRoleName(int roleId);

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
