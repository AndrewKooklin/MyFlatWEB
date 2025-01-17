using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyFlatWEB.Areas.Management.Models.Users;
using MyFlatWEB.Models.Account;

namespace MyFlatWEB.Data.Repositories.Abstract
{
    public interface IAccountRepository
    {
        Task<bool> CheckUserToDB(LoginModel model);

        void LogoutUser();

        Task<bool> CreateUser(RegisterModel model);

        Task<bool> AddNewUser(AddUserModel model);

        List<string> GetRoleNames();

        IEnumerable<IdentityRole> GetRoles();

        Task<List<string>> GetUserRoles(LoginModel model);

        Task<bool> CreateRole(IdentityRole role);

        Task<bool> DeleteRole(string id);

        List<IdentityUser> GetUsers();

        UserWithRolesModel GetUserWithRoles(string id);

        Task<bool> AddRoleToUser(RoleUserModel model);

        Task<bool> DeleteRoleUser(RoleUserModel model);

        Task<bool> DeleteRolesUser(string id);

        Task<bool> DeleteUser(string id);
    }
}
