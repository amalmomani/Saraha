﻿using Dapper;
using Microsoft.AspNetCore.SignalR;
using Saraha.Core.Common;
using Saraha.Core.Data;
using Saraha.Core.DTO;
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
        private readonly IHubContext<MessageHub> hubContext;

        public UserProfileRepository(IDbcontext dbContext, IHubContext<MessageHub> hubContext)
        {
            this.dbContext = dbContext;
            this.hubContext = hubContext;
        }


        public void CreateUserProfile(RegisterDTO userProfile)
        {
            var p = new DynamicParameters();
       
            p.Add("@UserNamee", userProfile.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Emaill", userProfile.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PhoneNumberr", userProfile.Phonenumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Genderr", userProfile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Birthdatee", userProfile.Birthdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Countryy", userProfile.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ImagePathh", userProfile.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("User_Package.CreateUser", p, commandType: CommandType.StoredProcedure);
            IEnumerable<Userprofile> users = dbContext.Connection.Query<Userprofile>("User_Package.GetAllUsers", commandType: CommandType.StoredProcedure);
            var user = users.Where(u => u.Email == userProfile.Email).SingleOrDefault();
            var pa = new DynamicParameters();


            pa.Add("@UserNamee", userProfile.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            pa.Add("@Passwordd", userProfile.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            pa.Add("@UserIdd", user.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            pa.Add("@RoleIdd", 2, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var r = dbContext.Connection.ExecuteAsync("Login_Package.CreateLogin", pa,
                commandType: CommandType.StoredProcedure);

            


        }

        public void DeleteUserProfile(int? id)
        {
            var p = new DynamicParameters();

            p.Add("@UserIdd", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("User_Package.DeleteUser", p,
              commandType: CommandType.StoredProcedure);

        }

        public List<Userprofile> GetallUserProfile()
        {
            IEnumerable<Userprofile> result = dbContext.Connection.Query<Userprofile>("User_Package.GetAllUsers", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool IsEmailExist(string email)
        {
            var p = new DynamicParameters();

            p.Add("@Emaill", email, dbType: DbType.String, direction: ParameterDirection.Input);

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

        public void UpdateUserProfile(Userprofile userProfile)
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

        }

        public int UsersCount()
        {
            IEnumerable<Userprofile> result = dbContext.Connection.Query<Userprofile>("User_Package.GetAllUsers", commandType: CommandType.StoredProcedure);

            int count= result.ToList().Count();
            return count;
        }
        public List<Userprofile> GetActiveUsers()
        {

            IEnumerable<Userprofile> result = dbContext.Connection.Query<Userprofile>("User_Package.GetActiveUsers", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }

        public List<LoginUsersDTO> GetAllLoginUsers()
        {
            IEnumerable<LoginUsersDTO> result = dbContext.Connection.Query<LoginUsersDTO>("GetAllLoginUsers", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Userprofile GetUserById(int userId)
        {
            var p = new DynamicParameters();

            p.Add("@UserIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Userprofile> result = dbContext.Connection.Query<Userprofile>("User_Package.GetUserById", p,
              commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
        }

        public List<Userprofile> SearchUser(string username, string country, string gender)
        {
            var p = new DynamicParameters();

            p.Add("@UserNamee", username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Countryy", country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Genderr", gender, dbType: DbType.String, direction: ParameterDirection.Input);


            IEnumerable<Userprofile> result = dbContext.Connection.Query<Userprofile>("User_Package.SearchUser",p, commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public async void GetNotifiactionByUserId(int userId)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@UserIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Notifications> result = dbContext.Connection.Query<Notifications>("Notifications_package_api.GetNotificationByUserId", parameter, commandType: CommandType.StoredProcedure);
            await hubContext.Clients.All.SendAsync("NotificationReceived", result);
            var notsCount = result.Where(x => x.Is_Read == 0 && x.UserTo == userId).ToList().Count();
            await hubContext.Clients.All.SendAsync("NotCount", notsCount);

        }
        public async  void UpdateNotIsRead( int userId ,int  notificationId)
        {
            var p = new DynamicParameters();
            p.Add("@NotificationIdd", notificationId, dbType: DbType.Int32, direction: ParameterDirection.Input);



            var result = dbContext.Connection.ExecuteAsync("Notifications_package_api.UpdateNotification",p,commandType: CommandType.StoredProcedure);

            var parameter = new DynamicParameters();
            parameter.Add("@UserIdd", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Notifications> nots = dbContext.Connection.Query<Notifications>("Notifications_package_api.GetNotificationByUserId", parameter, commandType: CommandType.StoredProcedure);
            await hubContext.Clients.All.SendAsync("NotificationReceived", nots);
            var notsCount = nots.Where(x => x.Is_Read == 0).ToList().Count();
            await hubContext.Clients.All.SendAsync("NotCount", notsCount);






        }
    }
}
