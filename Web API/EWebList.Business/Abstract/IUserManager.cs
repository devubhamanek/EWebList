using System.Collections.Generic;
using TimeTrackerMt.DataRepository.Model;

namespace TimeTrackerMt.Business.Abstract
{
    public interface IUserManager
    {
        AuthenticateResponse AuthenticateUser(AuthenticateRequest authenticateRequest);

        string RegisterExternalUser(UserMaster registerExternalUser, bool isGoogle, bool isFacebook);

        UserMaster AuthenticateUserWithGoogle(string email);

        UserMaster AuthenticateUserWithFacebook(string email);

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

        //bool ForgetPasswordAndEmail(string EmailId);

        //int ResetPassword(UserMaster user);

        //int UpdateUserMaster(UserMaster userMaster);

        //IEnumerable<UserMaster> GetAllUsers();

        //UserMaster ActiveDeactiveUserMaster(UserMaster User);

    }
}