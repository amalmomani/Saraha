using Dapper;
using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Saraha.Infra.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly IDbcontext dbContext;
        public UserProfileRepository(IDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateUserProfile(Userprofile userProfile)
        {
            var p = new DynamicParameters();
       
            p.Add("@UserNamee", userProfile.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Emaill", userProfile.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PhoneNumberr", userProfile.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Genderr", userProfile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Birthdatee", userProfile.Birthdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Countryy", userProfile.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ImagePathh", userProfile.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("User_Package.CreateUser", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool DeleteUserProfile(int? id)
        {
            var p = new DynamicParameters();

            p.Add("@UserIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("User_Package.DeleteUser", p,
              commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Userprofile> GetallUserProfile()
        {
            IEnumerable<Userprofile> result = dbContext.Connection.Query<Userprofile>("User_Package.GetAllUsers", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool IsEmailExist(string email)
        {
            var p = new DynamicParameters();

            p.Add("@Emaill", email, dbType: DbType.Int32, direction: ParameterDirection.Input);

            int result = dbContext.Connection.QuerySingleOrDefault<int>("User_Package.IsEmailExist", p,
              commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public bool UpdatePremium(int isPremium, int userId)
        {
            var p = new DynamicParameters();

            p.Add("@IsPremiumm", isPremium, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UserIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("User_Package.UpdatePremium", p,
              commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool UpdateUserProfile(Userprofile userProfile)
        {
            var p = new DynamicParameters();

            p.Add("@UserIdd", userProfile.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UserNamee", userProfile.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Emaill", userProfile.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PhoneNumberr", userProfile.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Genderr", userProfile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Birthdatee", userProfile.Birthdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Countryy", userProfile.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ImagePathh", userProfile.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("User_Package.UpdateUser", p,
                commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
