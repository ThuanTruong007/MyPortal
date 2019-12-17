using Dapper;
using DataManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static System.Data.CommandType;
using DataManagement.Repository.Interfaces;
namespace DataManagement.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public bool AddUser(User user)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@UserMobile", user.UserMobile);
                parameters.Add("@UserEmail", user.UserEmail);
                parameters.Add("@FaceBookUrl", user.FaceBookUrl);
                parameters.Add("@LinkedInUrl", user.LinkedInUrl);
                parameters.Add("@TwitterUrl", user.TwitterUrl);
                parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);
                using (var con = NewSqlConnection())
                {
                    SqlMapper.Execute(con, "AddUser", param: parameters, commandType: StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteUser(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            using (var con = NewSqlConnection())
            {
                SqlMapper.Execute(con, "DeleteUser", param: parameters, commandType: StoredProcedure);
                return true;
            }
        }
        public IList<User> GetAllUser()
        {
            using (var con = NewSqlConnection())
            {
                con.Open();
                var customerList = SqlMapper.Query<User>(con, "GetAllUsers", commandType: StoredProcedure).ToList();
                return customerList;
            }
        }
        public User GetUserById(int userId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerID", userId);
                using (var con = NewSqlConnection())
                {
                    return SqlMapper.Query<User>((SqlConnection)con, "GetUserById", parameters, commandType: StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", user.UserId);
                parameters.Add("@UserName", user.UserName);
                parameters.Add("@UserMobile", user.UserMobile);
                parameters.Add("@UserEmail", user.UserEmail);
                parameters.Add("@FaceBookUrl", user.FaceBookUrl);
                parameters.Add("@LinkedInUrl", user.LinkedInUrl);
                parameters.Add("@TwitterUrl", user.TwitterUrl);
                parameters.Add("@PersonalWebUrl", user.PersonalWebUrl);
                using (var con = NewSqlConnection())
                {
                    SqlMapper.Execute(con, "UpdateUser", param: parameters, commandType: StoredProcedure);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}