using BLL_TaskTracker.DTO;
using DAL_TaskTracker.Entities;
using System.Collections.Generic;
using Task = DAL_TaskTracker.Entities.Task;

namespace BL_TaskTracker.Interfaces
{
    public interface ITaskService
    {
        //void CreateTask(TaskDTO taskDTO);

        List<UserDTO> GetUsers();//
        List<AdminDTO> GetAdmins();//
        List<ClientDTO> GetClients();//

        List<EmployeeDTO> GetEmployees();//
        List<ManagerDTO> GetManagers();//

        List<TaskDTO> GetTasks();//
        List<StatusDTO> GetStatusReports();
        List<CommentDTO> GetComments();
        void Dispose();
    }
}
