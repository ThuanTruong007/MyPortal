using Dapper;
using DataManagement.Entities;
using DataManagement.Entities.Enums;
using DataManagement.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static System.Data.CommandType;

namespace DataManagement.Repository
{
    public class UserRepository : AppDbRepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory) { }

        public async Task<int> AddUser(User user)
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
                using (var con = base.NewSqlConnection())
                {
                    return await con.ExecuteScalarAsync<int>("Security.uspAddUser", param: parameters, commandType: StoredProcedure);                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async  Task<bool> DeleteUser(int userId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            using (var con = NewSqlConnection())
            {
                var id = await SqlMapper.ExecuteScalarAsync<int>(con, "[Security].[uspDeleteUser]", param: parameters, commandType: StoredProcedure);
                return userId==id;
            }
        }
        public async Task<IList<User>> GetAllUser()
        {
            using (var con = NewSqlConnection())
            {
                var result = await con.QueryAsync<User>("Security.uspGetAllUser", commandType: StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<User> GetUserById(int userId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                using (var con = NewSqlConnection())
                {
                    return await con.QuerySingleOrDefaultAsync<User>("Security.uspGetUserById", parameters, commandType: StoredProcedure);
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