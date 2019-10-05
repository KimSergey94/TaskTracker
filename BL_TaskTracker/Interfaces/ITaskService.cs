using DAL_TaskTracker.Entities;
using System.Collections.Generic;
using Task = DAL_TaskTracker.Entities.Task;

namespace BL_TaskTracker.Interfaces
{
    public interface ITaskService
    {
        //void MakeOrder(OrderDTO orderDto);
        List<User> GetUsers();
        List<Admin> GetAdmins();
        List<Client> GetClients();

        List<Employee> GetEmployees();
        List<Manager> GetManagers();

        List<Task> GetTasks();
        List<Status> GetStatusReports();
        List<Comment> GetComments();
        void Dispose();
    }
}
