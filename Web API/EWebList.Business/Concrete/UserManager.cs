using DemoDotNet.Common;
using System.Collections.Generic;
using TimeTrackerMt.Business.Abstract;
using TimeTrackerMt.DataRepository.Abstract;
using TimeTrackerMt.DataRepository.Concrete;
using TimeTrackerMt.DataRepository.Model;

namespace TimeTrackerMt.Business.Concrete
{
    public class UserManager : IUserManager
    {
        //private readonly IUserMasterRepository _userMasterRepository;

        public IUserRepository userRepository;
        private readonly Email _email;

        public UserManager(IUserRepository userMasterRepository, Email email)
        {
            userRepository = userMasterRepository;
            _email = email;
        }

        public AuthenticateResponse AuthenticateUser(AuthenticateRequest authenticateRequest)
        {
            authenticateRequest.Password = CrptographyEngine.Encrypt(authenticateRequest.Password);
            var result = userRepository.AuthenticateUser(authenticateRequest);
            if (result != null)
            {
                result.Password = CrptographyEngine.Decrypt(result.Password);
            }
            return result;
        }


        /* Register External User Method */
        public string RegisterExternalUser(UserMaster registerExternalUser, bool isGoogle, bool isFacebook)
        {
            return userRepository.RegisterExternalUser(registerExternalUser, isGoogle, isFacebook);
        }


        public UserMaster AuthenticateUserWithGoogle(string email)
        {
            return userRepository.GetUser(email);
        }

        public UserMaster AuthenticateUserWithFacebook(string email)
        {
            return userRepository.GetUser(email);
        }

        /* Email Exist Method which is checked user email is exists in database or not*/
        public string IsEmailExist(string email)
        {
            return userRepository.IsEmailExist(email);
        }

        //public IEnumerable<UserMaster> UserDataTableList(PaginationModel paginationModel)
        //{
        //    return _userMasterRepository.UserDataTableList(paginationModel);
        //}

        //public string UserAdd(UserMaster User)
        //{
        //    User.Password = CrptographyEngine.Encrypt(User.Password);
        //    var result = _userMasterRepository.UserAdd(User);
        //    _email.SuccessMessage(User);
        //    return result;
        //}
        //public EmailExist IsEmailExist(EmailExist User)
        //{
        //    return _userMasterRepository.IsEmailExist(User);
        //}
        //public UserMaster UserUpdate(UserMaster Update)
        //{
        //    Update.Password = CrptographyEngine.Encrypt(Update.Password);
        //    var result = _userMasterRepository.UserUpdate(Update);

        //    return result;
        //}
        //public IEnumerable<DropdownModel> GetUsersList(int CompanyId, int DepartmentId)
        //{
        //    return _userMasterRepository.GetUsersList( CompanyId,  DepartmentId);
        //}
        //public IEnumerable<DropdownModel> GetRolelist()
        //{
        //    return _userMasterRepository.GetRolelist();
        //}

        //public IEnumerable<DropdownModel> GetLoginRoleList(int LoginRoleId)
        //{
        //    return _userMasterRepository.GetLoginRoleList(LoginRoleId);
        //}


        //public IEnumerable<UserMaster> GetStatuslist()
        //{
        //    return _userMasterRepository.GetStatuslist();
        //}

        //public IEnumerable<UserMaster> GetReportinglist(int CompanyId)
        //{
        //    return _userMasterRepository.GetReportinglist(CompanyId);
        //}

        //public bool ForgetPasswordAndEmail(string EmailId)
        //{
        //    var user = _userMasterRepository.GetUserDetailByEmail(EmailId);
        //    if (user == null)
        //    {
        //        return false;
        //    }
        //    //else if (user.IsActive == false)
        //    //{
        //    //    return false;
        //    //}
        //    else
        //    {
        //        _email.ForgetPasswordMail(user);
        //        return true;
        //    }
        //}

        //public UserMaster GetUserDetailByEmail(string emailId)
        //{
        //    return _userMasterRepository.GetUserDetailByEmail(emailId);
        //}

        //public int ResetPassword(UserMaster user)
        //{
        //    user.Password = CrptographyEngine.Encrypt(user.Password);
        //    var result = _userMasterRepository.ResetPassword(user);
        //    //_email.PasswordChangeSucessMail(userMaster);
        //    return result;
        //}

        //public int UpdateUserMaster(UserMaster userMaster)
        //{
        //    userMaster.Password = CrptographyEngine.Encrypt(userMaster.Password);
        //    return _userMasterRepository.UpdateUserMaster(userMaster);
        //}

        //public IEnumerable<UserMaster> GetAllUsers()
        //{
        //    return _userMasterRepository.GetAllUsers();
        //}

        //public UserMaster ActiveDeactiveUserMaster(UserMaster User)
        //{

        //    var result = _userMasterRepository.ActiveDeactiveUserMaster(User);

        //    return result;
        //}
    }
}