using Light.GuardClauses;
using Microsoft.EntityFrameworkCore;
using VSDiTask.Core.Data;
using VSDiTask.Roles.Models;
using VSDiTask.Users.Data;

namespace VSDiTask.Roles.Services
{
    public interface IRoleService
    {
        Task<CreateRole.Response> CreateRoleAsync(CreateRole.RequestRole request);
        Task<CreateRole.Response> UpdateRoleAsync(CreateRole.RequestRole request);
        Task<CreateRole.Response> DeleteRoleAsync(string code);
        Task<List<GetRole.Response>> GetRolesAsync();
        Task<GetRole.Response> GetRolePermissionBy(GetRole.RequestRole request);

    }
    public class RoleService : IRoleService
    {
        private readonly IVSDiTaskDbContextFactory _vsdiTaskDbContextFactory;
        public RoleService(IVSDiTaskDbContextFactory dbContextFactory)
        {
            _vsdiTaskDbContextFactory = dbContextFactory;

        }

        public async Task<CreateRole.Response> CreateRoleAsync(CreateRole.RequestRole request)
        {
            request.MustNotBeNull();
            request.RoleId.MustNotBeNullOrWhiteSpace();
            request.RoleName.MustNotBeNullOrEmpty();

            CreateRole.Response FailedResult(StatusCode statuscode)
            {
                return new CreateRole.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            if (await IsRoleExist(context, request.RoleId))
            {
                return FailedResult(StatusCode.Company_already_exist);
            }

            var entity = context.Role.Add(new Core.Entities.Role
            {
                RoleId = request.RoleId,
                RoleName = request.RoleName,
                IsAdmin = request.IsAdmin,
                Description = request.Description
            }).Entity;

            await context.SaveChangesAsync();
            return new CreateRole.Response(true);
        }

        public async Task<CreateRole.Response> DeleteRoleAsync(string code)
        {
            code.MustNotBeNullOrWhiteSpace();

            CreateRole.Response FailedResult(StatusCode statuscode)
            {
                return new CreateRole.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            var role = await context.Role.Where(x => x.RoleId == code).FirstOrDefaultAsync();
            if (role == null)
                return FailedResult(StatusCode.Role_not_exist);

            var entity = context.Role.Remove(role).Entity;

            await context.SaveChangesAsync();
            return new CreateRole.Response(true);
        }

        public async Task<GetRole.Response> GetRolePermissionBy(GetRole.RequestRole request)
        {
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();
            return await context.Role
                .Where(r => r.RoleId == request.RoleId)
                .Select(x => new GetRole.Response
                {
                    RoleId = x.RoleId,
                    RoleName = x.RoleName,
                    IsAdmin = x.IsAdmin,
                    Description = x.Description,
                    Permissions = context.Permissions
                        .Where(y => y.RoleId == request.RoleId)
                        .Select(c => new GetRole.RolePermission
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

        public async Task<List<GetRole.Response>> GetRolesAsync()
        {
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();
            return await context.Role
                .Select(x => new GetRole.Response
                {
                    RoleId = x.RoleId,
                    RoleName = x.RoleName,
                    IsAdmin = x.IsAdmin,
                    Description = x.Description
                })
                .ToListAsync();
        }

        public async Task<CreateRole.Response> UpdateRoleAsync(CreateRole.RequestRole request)
        {
            request.MustNotBeNull();
            request.RoleId.MustNotBeNullOrWhiteSpace();
            request.RoleName.MustNotBeNullOrEmpty();

            CreateRole.Response FailedResult(StatusCode statuscode)
            {
                return new CreateRole.Response(statuscode);
            }
            using var context = _vsdiTaskDbContextFactory.CreateDbContext();

            var role = await context.Role.Where(x => x.RoleId == request.RoleId).FirstOrDefaultAsync();
            if (role == null)
                return FailedResult(StatusCode.Role_not_exist);

            role.RoleName = request.RoleName;
            role.IsAdmin = request.IsAdmin;
            role.Description = request.Description;

            var entity = context.Role.Update(role).Entity;

            await context.SaveChangesAsync();
            return new CreateRole.Response(true);
        }

        private Task<bool> IsRoleExist(VSDiTaskDBContext context, string code)
        {
            return context.Role.Where(x => x.RoleId == code)
                .AnyAsync();
        }
    }
}
