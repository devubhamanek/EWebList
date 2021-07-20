using System.Collections.Generic;
using TimeTrackerMt.DataRepository.Model;

namespace TimeTrackerMt.DataRepository.Abstract
{
    public interface IUserRepository
    {
        AuthenticateResponse AuthenticateUser(AuthenticateRequest authenticateRequest);

        string RegisterExternalUser(UserMaster registerExternalUser, bool isGoogle, bool isFacebook);

        UserMaster GetUser(string email);

        string IsEmailExist(string email);

        //IEnumerable<UserMaster> UserDataTableList(PaginationModel paginationModel);

        //string UserAdd(UserMaster User);
        //EmailExist IsEmailExist(EmailExist User);
        //UserMaster UserUpdate(UserMaster Update);
        //IEnumerable<DropdownModel> GetUsersList(int CompanyId, int DepartmentId);
        //IEnumerable<DropdownModel> GetRolelist();
        //IEnumerable<DropdownModel> GetLoginRoleList(int LoginRoleId);
        //IEnumerable<UserMaster> GetStatuslist();

        //IEnumerable<UserMaster> GetReportinglist(int CompanyId);

        //UserMaster GetUserDetailByEmail(string emailId);

        //int ResetPassword(UserMaster user);

        //IEnumerable<UserMaster> GetAllUsers();

        //int UpdateUserMaster(UserMaster userMaster);

        //UserMaster ActiveDeactiveUserMaster(UserMaster User);
    }
}