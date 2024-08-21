using BlazorApp.Models;

namespace BlazorApp.DataAccess
{
    public interface IGroupRightAccessLayer
    {
        public IEnumerable<GroupRight> GetRelatedGroupRightsByPermissionGroupId(int id);
    }
    public class GroupRightAccessLayer : IGroupRightAccessLayer
    {
        private UserGroupsContext _context;

        public GroupRightAccessLayer(UserGroupsContext _context)
        {
                this._context = _context;
        }
        public IEnumerable<GroupRight> GetRelatedGroupRightsByPermissionGroupId(int id)
        {
            IEnumerable<GroupRight> groupRights = this._context.GroupRights.Where(r => r.PermissionGroupsId == id);
            Console.WriteLine("_________________________________________________");
            foreach (GroupRight groupRight in groupRights)
            {
                Console.WriteLine($"Id of the PermissionGroup is: {id}");
                Console.WriteLine(groupRight.Area);
            }
            Console.WriteLine("_________________________________________________");
            return groupRights;
        }
    }
}
