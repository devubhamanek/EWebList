using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using TimeTrackerMt.DataRepository.Abstract;
using TimeTrackerMt.DataRepository.Model;

namespace TimeTrackerMt.DataRepository.Concrete
{
    public class UserRepository : IUserRepository
    {

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        public AuthenticateResponse AuthenticateUser(AuthenticateRequest authenticateRequest)
        {
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Email", authenticateRequest.Email);
                parameters.Add("@Password", authenticateRequest.Password);

                var loginUserData = SqlMapper.Query<AuthenticateResponse>(con, "usp_AuthorizeUser", param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                con.Close();
                return loginUserData;
            }
        }


        /* Used for Register external User */
        public string RegisterExternalUser(UserMaster registerExternalUser, bool isGoogle, bool isFacebook)
        {
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@email", registerExternalUser.Email);
                parameters.Add("@status", true);
                parameters.Add("@firstName", registerExternalUser.FirstName);
                parameters.Add("@lastName", registerExternalUser.LastName);
                parameters.Add("@isGoogle", isGoogle);
                parameters.Add("@isFacebook", isFacebook);
                var UserData = SqlMapper.Query<UserMaster>(con, "usp_RegisterExternalUser", param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                string msg = string.Empty;

                con.Close();
                return msg;
            }
        }


        public UserMaster GetUser(string email)
        {
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@email", email);

                var loginUserData = SqlMapper.Query<UserMaster>(con, "usp_GetUser", param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                con.Close();
                return loginUserData;
            }
        }

        public string IsEmailExist(string email)
        {
            string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@email", email);

                var result = Convert.ToString(con.ExecuteScalar("usp_IsEmailExist", param: parameters, commandType: CommandType.StoredProcedure));
                con.Close();
                return result;
            }

        }
        }
}
//public IEnumerable<UserMaster> UserDataTableList(PaginationModel paginationModel)
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        DynamicParameters parameters = new DynamicParameters();
//        parameters.Add("@iDisplayLength", paginationModel.DisplayLength);
//        parameters.Add("@iDisplayStart", paginationModel.DisplayStart);
//        parameters.Add("@sSearch", paginationModel.Search);
//        parameters.Add("@iSortCol", paginationModel.SortCol);
//        parameters.Add("@sSortDir", paginationModel.SortDir);
//        parameters.Add("@CompanyId", paginationModel.CompanyId);
//        parameters.Add("@DepartmentId", paginationModel.DepartmentId);
//        parameters.Add("@RoleId", paginationModel.RoleId);
//        parameters.Add("@CreatedBy", paginationModel.CreatedBy);

//        var result = SqlMapper.Query<UserMaster>(con, "UserDataTableList", param: parameters, commandType: CommandType.StoredProcedure);
//        con.Close();
//        return result;
//    }
//}

//public string UserAdd(UserMaster User)
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        DynamicParameters parameters = new DynamicParameters();
//        parameters.Add("@FirstName", User.FirstName);
//        parameters.Add("@LastName", User.LastName);
//        parameters.Add("@Email", User.Email);
//        parameters.Add("@Password", User.Password);
//        parameters.Add("@DepartmentId", User.DepartmentId);
//        parameters.Add("@Gender", User.Gender);
//        parameters.Add("@RoleId", User.RoleId);
//        parameters.Add("@LoginRoleId", User.LoginRoleId);
//        parameters.Add("@LoginDepartmentId", User.LoginDepartmentId);
//        //parameters.Add("@StatusId", User.StatusId);
//        parameters.Add("@ReportingTo", User.ReportingTo);
//        parameters.Add("@CompanyId", User.CompanyId);
//        parameters.Add("@CreatedBy", User.CreatedBy);
//        //parameters.Add("@AvailableUser",User.AvailableUser);
//        parameters.Add("AvailableUser", dbType: DbType.Int32, direction: ParameterDirection.Output);

//        var UserData = SqlMapper.Query<UserMaster>(con, "user_Add", param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
//        int count = parameters.Get<int>("AvailableUser");
//        string msg = string.Empty;
//        if (count > 0)
//        {
//            msg = "You cannot add more users !To add more users contact provider";
//        }

//        con.Close();
//        return msg;
//    }
//}
//public EmailExist IsEmailExist(EmailExist User)
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        DynamicParameters parameters = new DynamicParameters();
//        parameters.Add("@Email", User.Email);
//        parameters.Add("@UserId", User.UserId);
//        var result = SqlMapper.Query<EmailExist>(con, "usp_EmailExist", param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
//        con.Close();
//        return result;
//    }
//}
//public UserMaster UserUpdate(UserMaster Update)
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        DynamicParameters parameters = new DynamicParameters();
//        parameters.Add("@UserId", Update.UserId);
//        parameters.Add("@FirstName", Update.FirstName);
//        parameters.Add("@LastName", Update.LastName);
//        parameters.Add("@Email", Update.Email);
//        parameters.Add("@Password", Update.Password);
//        parameters.Add("@DepartmentId", Update.DepartmentId);
//        parameters.Add("@Gender", Update.Gender);
//        parameters.Add("@RoleId", Update.RoleId);
//        parameters.Add("@LoginRoleId", Update.LoginRoleId);
//        parameters.Add("@LoginDepartmentId", Update.LoginDepartmentId);
//        //parameters.Add("@StatusId", Update.StatusId);
//        parameters.Add("@ReportingTo", Update.ReportingTo);
//        parameters.Add("@CompanyId", Update.CompanyId);
//        parameters.Add("@UpdatedBy", Update.UpdatedBy);

//        var UserData = SqlMapper.Query<UserMaster>(con, "UserUpdate", param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

//        if (UserData == null) return null;

//        con.Close();
//        return UserData;
//    }
//}
//public IEnumerable<DropdownModel> GetUsersList(int CompanyId, int DepartmentId)
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        DynamicParameters parameters = new DynamicParameters();
//        parameters.Add("@CompanyId", CompanyId);
//        //parameters.Add("@DepartmentId", DepartmentId);

//        var result = SqlMapper.Query<DropdownModel>(con, "GetUsersList", parameters, commandType: CommandType.StoredProcedure);
//        con.Close();
//        return result;
//    }
//}
//public IEnumerable<DropdownModel> GetRolelist()
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        var result = SqlMapper.Query<DropdownModel>(con, "RolesForProject", null, commandType: CommandType.StoredProcedure);
//        con.Close();
//        return result;
//    }
//}


//public IEnumerable<DropdownModel> GetLoginRoleList(int LoginRoleId)
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        DynamicParameters parameters = new DynamicParameters();
//        parameters.Add("@LoginRoleId", LoginRoleId);
//        var result = SqlMapper.Query<DropdownModel>(con, "RolesControl", parameters, commandType: CommandType.StoredProcedure);
//        con.Close();
//        return result;
//    }
//}

//public IEnumerable<UserMaster> GetStatuslist()
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        var result = SqlMapper.Query<UserMaster>(con, "ProjectStatusControl", null, commandType: CommandType.StoredProcedure);
//        con.Close();
//        return result;
//    }
//}

//public IEnumerable<UserMaster> GetReportinglist(int CompanyId)
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        DynamicParameters parameters = new DynamicParameters();
//        parameters.Add("@CompanyId", CompanyId);

//        var result = SqlMapper.Query<UserMaster>(con, "ReportingControl", parameters, commandType: CommandType.StoredProcedure);
//        con.Close();
//        return result;
//    }
//}

//public UserMaster GetUserDetailByEmail(string emailId)
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        DynamicParameters parameters = new DynamicParameters();
//        parameters.Add("@Email", emailId);
//        var result = SqlMapper.Query<UserMaster>(con, "ForgotPassword", param: parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
//        con.Close();
//        return result;
//    }
//}

//public int ResetPassword(UserMaster user)
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        DynamicParameters parameters = new DynamicParameters();
//        parameters.Add("@UserId", user.UserId);
//        parameters.Add("@Password", user.Password);
//        var result = Convert.ToInt32(con.ExecuteScalar("ResetPassword", param: parameters, commandType: CommandType.StoredProcedure));
//        con.Close();
//        return result;
//    }
//}

//public int UpdateUserMaster(UserMaster userMaster)
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        DynamicParameters parameters = new DynamicParameters();
//        parameters.Add("@UserId", userMaster.UserId);
//        parameters.Add("@FirstName", userMaster.FirstName);
//        parameters.Add("@LastName", userMaster.LastName);
//        parameters.Add("@Email", userMaster.Email);
//        parameters.Add("@Gender", userMaster.Gender);
//        parameters.Add("@Password", userMaster.Password);
//        parameters.Add("@UpdatedBy", userMaster.UpdatedBy);

//        var result = Convert.ToInt32(con.ExecuteScalar("ProfileUpdate", param: parameters, commandType: CommandType.StoredProcedure));
//        con.Close();
//        return result;
//    }
//}

//public IEnumerable<UserMaster> GetAllUsers()
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        var result = SqlMapper.Query<UserMaster>(con, "GetAllUsers", null, commandType: CommandType.StoredProcedure);
//        con.Close();
//        return result;
//    }
//}

//private string generateJwtToken(AuthenticateResponse user)
//{
//    var tokenHandler = new JwtSecurityTokenHandler();
//    var key = Encoding.ASCII.GetBytes(_configuration["JwtAuthentication:Secret"]);
//    double tokenExpiryTime = Convert.ToDouble(_configuration["JwtAuthentication:ExpireTime"]);
//    var tokenDescriptor = new SecurityTokenDescriptor
//    {
//        Subject = new ClaimsIdentity(new Claim[]
//        {
//            new Claim(ClaimTypes.Name, user.UserId.ToString())
//        }),
//        Expires = DateTime.UtcNow.AddHours(tokenExpiryTime),
//        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//    };
//    var token = tokenHandler.CreateToken(tokenDescriptor);
//    return tokenHandler.WriteToken(token);
//}

//public UserMaster ActiveDeactiveUserMaster(UserMaster User)
//{
//    string connectionString = _configuration["ConnectionStrings:DefaultConnection"];
//    using (SqlConnection con = new SqlConnection(connectionString))
//    {
//        DynamicParameters parameters = new DynamicParameters();
//        parameters.Add("@UserId", User.UserId);

//        if (User.IsActive)
//        {
//            parameters.Add("@TypeStatusId", 1);
//        }
//        else
//        {
//            parameters.Add("@TypeStatusId", 0);
//        }

//        var result = SqlMapper.Query<UserMaster>(con, "ActiveDeactiveUserMaster", param: parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
//        con.Close();
//        return result;
//    }
//}
