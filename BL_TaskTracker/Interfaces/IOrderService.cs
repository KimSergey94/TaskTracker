using BLL_TaskTracker.DTO;
using System.Collections.Generic;

namespace BLL_TaskTracker.Interfaces
{
    public interface IOrderService
    {
        void AddTask(TaskDTO taskDTO);
        void EditTask(TaskDTO taskDTO);
        void DeleteTask(TaskDTO taskDTO);

        void AddStep(StepDTO stepDTO);
        void EditStep(StepDTO taskDTO);
        void DeleteStep(StepDTO stepDTO);

        void AddComment(CommentDTO commentDTO);
        void EditComment(CommentDTO commentDTO);
        void DeleteComment(CommentDTO commentDTO);

        void AddEmployee(EmployeeDTO employeeDTO);
        void AddManager(ManagerDTO ManagerDTO);
        void AddAdmin(AdminDTO adminDTO);
        void AddUser(UserDTO userDTO);
        void AddClient(ClientDTO clientDTO);


        string GetUserRoleName(int roleId);
        TaskDTO GetTaskWithIncludedSteps(TaskDTO task);
        StepDTO GetStepWithIncludedComments(StepDTO step);
        List<EmployeeDTO> GetAllManagers();
        void SendEmail(int clientId, int managerId, int taskId);




        List<UserDTO> GetUsers();//
        List<AdminDTO> GetAdmins();//
        List<ClientDTO> GetClients();//

        List<EmployeeDTO> GetEmployees();//
        List<ManagerDTO> GetManagers();//

        List<TaskDTO> GetTasks();//
        List<StepDTO> GetSteps();
        List<CommentDTO> GetComments();
        List<RoleDTO> GetRoles();
        List<EmailDTO> GetEmails();
        void Dispose();
    }
}
