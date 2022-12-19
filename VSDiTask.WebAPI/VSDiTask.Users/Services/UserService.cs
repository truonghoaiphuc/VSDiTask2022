﻿using Light.GuardClauses;
using Microsoft.EntityFrameworkCore;
using VSDiTask.Common.Extensions;
using VSDiTask.Core.Data;
using VSDiTask.Core.Entities.Enums;
using VSDiTask.Users.Data;
using VSDiTask.Users.Models;

namespace VSDiTask.Users.Services
{
    public interface IUserService
    {

        Task<bool> IsValidUserAccountAsync(UserLogin user);

        Task<UserToken> GetUserTokenInfoAsync(string username);

        Task<CreateUser.ResponseUser> AddUserAsync(CreateUser.RequestUser request);
        Task<GetUser.Response> GetUserByAsync(string username);

    }
    public class UserService : IUserService
    {
        private readonly IVSDiTaskDbContextFactory _dbContextFactory;
        public UserService(IVSDiTaskDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<CreateUser.ResponseUser> AddUserAsync(CreateUser.RequestUser request)
        {
            request.MustNotBeNull();
            request.UserName.MustNotBeNullOrWhiteSpace();
            //request.CompName.MustNotBeNullOrEmpty();

            CreateUser.ResponseUser FailedResult(StatusCode statuscode)
            {
                return new CreateUser.ResponseUser(statuscode);
            }
            using var context = _dbContextFactory.CreateDbContext();

            if (await IsUserExist(context, request.UserName))
            {
                return FailedResult(StatusCode.User_already_exist);
            }

            var entity = context.AppUsers.Add(new Core.Entities.User
            {
                UserName = request.UserName,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Gender = request.Gender,
                Avatar = request.Avatar,
                Status = request.Status,
                DeptId = request.DeptId,
                RoleId = request.RoleId
            }).Entity;

            await context.SaveChangesAsync();
            return new CreateUser.ResponseUser(true);
        }

        public async Task<GetUser.Response> GetUserByAsync(string username)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.AppUsers
                .Where(r => r.UserName == username)
                .Select(x => new GetUser.Response
                {
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber,
                    Address = x.Address,
                    DateOfBirth = x.DateOfBirth,
                    Gender = x.Gender,
                    Avatar = x.Avatar,
                    Permissions = context.Permissions
                        .Where(y => y.RoleId == x.RoleId)
                        .Select(c => new GetUser.UserPermission
                        {
                            RoleId = c.RoleId,
                            FunctionId = c.FunctionId,
                            CanRead = c.CanRead,
                            CanCreate = c.CanCreate,
                            CanUpdate = c.CanUpdate,
                            CanDelete = c.CanDelete
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<UserToken> GetUserTokenInfoAsync(string username)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.AppUsers
                .Where(x => x.UserName == username)
                .Select(x => new UserToken
                {
                    UserName = x.UserName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Role = x.RoleId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidUserAccountAsync(UserLogin user)
        {
            using var context = _dbContextFactory.CreateDbContext();

            var hash = HashExtensions.Hash(user.Password);
            var valid = await context.AppUsers
                .Where(u => u.UserName == user.UserName && u.Password == hash && u.Status == UserStatus.Active)
                .AnyAsync();
            return valid;
        }

        private Task<bool> IsUserExist(VSDiTaskDBContext context, string code)
        {
            return context.AppUsers.Where(x => x.UserName == code)
                .AnyAsync();
        }
    }
}
