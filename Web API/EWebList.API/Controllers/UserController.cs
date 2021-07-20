using DemoDotNet.API;
using DemoDotNet.DataRepository.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using TimeTrackerMt.Business.Abstract;
using TimeTrackerMt.DataRepository.Model;

namespace TimeTrackerMt.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region "Declarations & Constructors"

        private ImageHelpers _imageHelpers;
        //private IUserMasterBusiness _userMasterBusiness;
        public IUserManager userManager;
        private readonly IConfiguration _config;
        public UserController(IUserManager userMasterBusiness, ImageHelpers imageHelpers, IConfiguration config)
        {
            userManager = userMasterBusiness;
            _imageHelpers = imageHelpers;
            _config = config;
        }

        #endregion "Declarations & Constructors"

        [AllowAnonymous]
        [HttpPost("authenticateuser")]
        public Response AuthenticateUser([FromBody] AuthenticateRequest authenticateRequest)
        {
            var authentication = userManager.AuthenticateUser(authenticateRequest);
            Response response = new Response(HttpStatusCode.OK, authentication, AppConstant.Success);
            return response;
        }



        /// <summary>
        /// POST api/User/AuthenticateByGoogle used for google auth
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>        
        [HttpPost]
        [Route("AuthenticateByGoogle")]
        [AllowAnonymous]
        public Response AuthenticateByGoogle(UserMaster registerUser)
        {
            UserMaster users = new UserMaster();

            string email = userManager.IsEmailExist(registerUser.Email);

            if (email == registerUser.Email)
            {
                users = userManager.AuthenticateUserWithGoogle(registerUser.Email);
                if (users.DOB == null)
                {
                    users.registrationStatus = "in_proccess";
                }
                else
                {
                    users.registrationStatus = "registered";
                }

                Response response = new Response(HttpStatusCode.OK, users, AppConstant.Success);
                return response;
            }
            else
            {
                userManager.RegisterExternalUser(registerUser, true, false);

                users = userManager.AuthenticateUserWithGoogle(registerUser.Email);

                if (users.DOB == null)
                {
                    users.registrationStatus = "in_proccess";
                }
                else
                {
                    users.registrationStatus = "registered";
                }

                Response response = new Response(HttpStatusCode.OK, users, AppConstant.Success);
                return response;
            }

        }


        [HttpPost]
        [Route("AuthenticateByFacebook")]
        [AllowAnonymous]
        public Response AuthenticateByFacebook(UserMaster registerUser)
        {
            UserMaster users = new UserMaster();

            string email = userManager.IsEmailExist(registerUser.Email);

            if (email == registerUser.Email)
            {
                users = userManager.AuthenticateUserWithFacebook(registerUser.Email);
                if (users.DOB == null)
                {
                    users.registrationStatus = "in_proccess";
                }
                else
                {
                    users.registrationStatus = "registered";
                }

                Response response = new Response(HttpStatusCode.OK, users, AppConstant.Success);
                return response;
            }
            else
            {
                userManager.RegisterExternalUser(registerUser, false, true);

                users = userManager.AuthenticateUserWithFacebook(registerUser.Email);

                if (users.DOB == null)
                {
                    users.registrationStatus = "in_proccess";
                }
                else
                {
                    users.registrationStatus = "registered";
                }

                Response response = new Response(HttpStatusCode.OK, users, AppConstant.Success);
                return response;
            }

        }


        /* GenerateJSONWebToken method is used for create JWT token for forgot password*/
        //private string GenerateJSONWebToken(UserMaster userInfo)
        //{
        //    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    JwtSecurityToken token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Issuer"],
        //      null,
        //      // expires: DateTime.Now.AddMinutes(1),
        //      expires: DateTime.Now.AddHours(24),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}



//[HttpPost("UserDataTableList")]
//public Response UserDataTableList([FromBody] PaginationModel paginationModel)
//{
//    var result = _userMasterBusiness.UserDataTableList(paginationModel);
//    //result.Password = CrptographyEngine.Decrypt(result.Password);

//    for (var i = 0; i < result.ToList().Count; i++)
//    {
//        ///var Pass = AdminManager.GetBatchGrantTableData(result.ToList()[i].Password);
//        result.ToList()[i].Password = CrptographyEngine.Decrypt(result.ToList()[i].Password);
//        //result = result.ToList()[].Password
//    }

//    Response response = new Response(HttpStatusCode.OK, result, AppConstant.Success);
//    return response;
//}

//[AllowAnonymous]
//[HttpPost("useradd")]
//public Response UserAdd([FromBody] UserMaster User)
//{
//    var authentication = _userMasterBusiness.UserAdd(User);
//    Response response = new Response(HttpStatusCode.OK, authentication, AppConstant.Success);
//    return response;
//}

//[HttpPost]
//[Route("IsEmailExist")]
//public Response IsEmailExist([FromBody] EmailExist User)
//{
//    var result = _userMasterBusiness.IsEmailExist(User);
//    Response response = new Response(HttpStatusCode.OK, result, AppConstant.Success);

//    return response;
//}

//[AllowAnonymous]
//[HttpPost("UserUpdate")]
//public Response UserUpdate([FromBody] UserMaster Update)
//{
//    var authentication = _userMasterBusiness.UserUpdate(Update);
//    Response response = new Response(HttpStatusCode.OK, authentication, AppConstant.Success);
//    return response;
//}

//[HttpGet("GetUserList")]
//public Response GetUsersList(int CompanyId, int DepartmentId)
//{
//    var users = _userMasterBusiness.GetUsersList(CompanyId, DepartmentId);
//    Response response = new Response(HttpStatusCode.OK, users, AppConstant.Success);
//    return response;
//}

//[AllowAnonymous]
//[HttpGet("getRolelist")]
//public Response GetRolelist()
//{
//    var result = _userMasterBusiness.GetRolelist();
//    Response response = new Response(HttpStatusCode.OK, result, AppConstant.Success);
//    return response;
//}

//[AllowAnonymous]
//[HttpGet("getLoginRoleList/{LoginRoleId}")]
//public Response GetLoginRoleList(int LoginRoleId)
//{
//    var result = _userMasterBusiness.GetLoginRoleList(LoginRoleId);
//    Response response = new Response(HttpStatusCode.OK, result, AppConstant.Success);
//    return response;
//}

//[AllowAnonymous]
//[HttpGet("getStatuslist")]
//public Response GetStatuslist()
//{
//    var result = _userMasterBusiness.GetStatuslist();
//    Response response = new Response(HttpStatusCode.OK, result, AppConstant.Success);
//    return response;
//}

//[AllowAnonymous]
//[HttpGet("getReportinglist/{CompanyId}")]
//public Response GetReportinglist(int CompanyId)
//{
//    var result = _userMasterBusiness.GetReportinglist(CompanyId);
//    Response response = new Response(HttpStatusCode.OK, result, AppConstant.Success);
//    return response;
//}

//#region "Get Methods"

//[AllowAnonymous]
//[HttpGet("forgetpassword/{email}")]
//public Response ForgetPassword(string email)
//{
//    var users = _userMasterBusiness.ForgetPasswordAndEmail(email);
//    Response response = new Response(HttpStatusCode.OK, users, AppConstant.Success);
//    return response;
//}

//[AllowAnonymous]
//[HttpGet("getuserdetailforresetpassword/{userId}")]
//public Response GetUserDetailForResetPassword(long userId)
//{

//    Response response = new Response(HttpStatusCode.OK, AppConstant.Success);
//    return response;
//}

//[AllowAnonymous]
//[HttpPost("resetPassword")]
//public Response ResetPassword([FromBody] UserMaster user)
//{
//    var Data = _userMasterBusiness.ResetPassword(user);
//    Response response = new Response(HttpStatusCode.OK, Data, AppConstant.Success);
//    return response;
//}

//[HttpGet("getusers")]
//public Response GetUsers()
//{
//    var users = _userMasterBusiness.GetAllUsers();
//    Response response = new Response(HttpStatusCode.OK, users, AppConstant.Success);
//    return response;
//}

//#endregion "Get Methods"

//#region "Post Methods"

//[HttpPost("updateusermaster")]
//public Response UpdateUserMaster([FromBody] UserMaster userMaster)
//{
//    var user = _userMasterBusiness.UpdateUserMaster(userMaster);
//    Response response = new Response(HttpStatusCode.OK, user, AppConstant.Success);
//    return response;
//}


//[AllowAnonymous]
//[HttpPost("activedeactiveusermaster")]
//public Response ActiveDeactiveUserMaster([FromBody] UserMaster User)
//{
//    var user = _userMasterBusiness.ActiveDeactiveUserMaster(User);
//    Response response = new Response(HttpStatusCode.OK, user, AppConstant.Success);
//    return response;
//}



//#endregion "Post Methods"
