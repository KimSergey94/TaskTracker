using DAL_TaskTracker.EF;
using DAL_TaskTracker.Entities;
using System.Linq;
using System.Web.Security;
using Role = DAL_TaskTracker.Entities.Role;

namespace TaskTracker.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        
        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (TaskTrackerContext db = new TaskTrackerContext("TaskTrackerDb"))
            {
                User user = db.Users.FirstOrDefault(u => u.Email == username);
                if (user != null)
                {
                    Role userRole = db.Roles.Find(user.RoleId);
                    if (userRole != null) { roles = new string[] { userRole.Name }; }
                }
            }
            return roles;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            using (TaskTrackerContext db = new TaskTrackerContext("TaskTrackerDb"))
            {
                User user = db.Users.FirstOrDefault(u => u.Email == username);
                if (user != null)
                {
                    Role userRole = db.Roles.Find(user.RoleId);
                    if (userRole != null && userRole.Name == roleName)
                    {
                        outputResult = true;
                    }
                }
            }
            return outputResult;
        }


        public override string[] GetUsersInRole(string roleName)
        {
            throw new System.NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new System.NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new System.NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new System.NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new System.NotImplementedException();
        }


    }
}
