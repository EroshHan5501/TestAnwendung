using BlazorApp.Models;

namespace BlazorApp.DataAccess
{
    public interface IPermissionGroupAccessLayer
    {
        IEnumerable<PermissionGroup> GetAllPermissionGroups();
        void AddPermissionGroup(PermissionGroup permissionGroup);
        void UpdatePermissionGroup(PermissionGroup permissionGroup);
    }
    public class PermissionGroupAccessLayer : IPermissionGroupAccessLayer
    {
        // Make private
        public UserGroupsContext _context;

        public PermissionGroupAccessLayer(UserGroupsContext context)
        {
            this._context = context;
        }

        public IEnumerable<PermissionGroup> GetAllPermissionGroups()
        {
            try
            {
                return this._context.PermissionGroups.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void AddPermissionGroup(PermissionGroup permissionGroup)
        {
            try
            {
                this._context.PermissionGroups.Add(permissionGroup);
                this._context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdatePermissionGroup(PermissionGroup permissionGroup)
        {
            try
            {
                Console.WriteLine("AccessLayer Update");
                Console.WriteLine(permissionGroup.Name);
                this._context.PermissionGroups.Update(permissionGroup);
                this._context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
