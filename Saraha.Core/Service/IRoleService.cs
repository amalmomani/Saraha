using Saraha.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Core.Service
{
    public interface IRoleService
    {
        public List<Role> GetallRoles();
        public bool CreateRole(Role role);
        public bool UpdateRole(Role role);
        public bool DeleteRole(int? id);
    }
}

