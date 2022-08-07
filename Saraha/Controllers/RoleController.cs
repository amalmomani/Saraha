using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saraha.Core.Data;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saraha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;
        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        public List<Role> GetallRoles()
        {
            return roleService.GetallRoles();
        }

        [HttpPost]
        public bool CreateRole([FromBody]Role role)
        {
            return roleService.CreateRole(role);
        }

        [HttpPut]
        public bool UpdateRole([FromBody] Role role)
        {
            return roleService.UpdateRole(role);
        }
        [HttpDelete]
        [Route("{id}")]
        public bool DeleteRole(int? id)
        {
            return roleService.DeleteRole(id);
        }
    }
}
