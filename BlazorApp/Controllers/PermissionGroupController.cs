using BlazorApp.DataAccess;
using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp.Controllers
{
    [ApiController]
    [Route("groups")]
    public class PermissionGroupController : Controller
    {
        IPermissionGroupAccessLayer _permissionGroupAccessLayer;

        public PermissionGroupController(IPermissionGroupAccessLayer permissionGroupAccessLayer)
        {
            this._permissionGroupAccessLayer = permissionGroupAccessLayer;

        }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        [HttpGet]
        [Route("all")]
        public IEnumerable<PermissionGroup> GetAllGroupNames()
        {
            return this._permissionGroupAccessLayer.GetAllPermissionGroups();
        }

        [HttpPost]
        [Route("create")]
        // TODO Serialize Object directly from Body
        // public void CreatePermissionGroup([FromBody] PermissionGroup permissionGroup)
        public void CreatePermissionGroup(PermissionGroup permissionGroup)
        {
            Console.WriteLine("Check new Object:");
            Console.WriteLine(permissionGroup.Id);
            // Look closer at this
            if (ModelState.IsValid)
            {
                Console.WriteLine("Check valid Object:");
                Console.WriteLine(permissionGroup.Id);
                this._permissionGroupAccessLayer.AddPermissionGroup(permissionGroup);
            }
        }

        [HttpPut]
        [Route("update")]
        public void UpdatePermissionGroup(PermissionGroup permissionGroup)
        {
            if (ModelState.IsValid)
            {
                this._permissionGroupAccessLayer.UpdatePermissionGroup(permissionGroup);
            }
        }
    }
}
