using BlazorApp.DataAccess;
using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers
{
    [ApiController]
    [Route("rights")]
    public class GroupRightController : Controller
    {
        private IGroupRightAccessLayer _groupRightAccessLayer;

        public GroupRightController(IGroupRightAccessLayer GroupRightAccessLayer)
        {
            this._groupRightAccessLayer = GroupRightAccessLayer;
        }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        [HttpGet]
        [Route("{id}/related")]
        public IEnumerable<GroupRight> GetRelatedRights(int id)
        {
            return this._groupRightAccessLayer.GetRelatedGroupRightsByPermissionGroupId(id);
        }
    }
}
