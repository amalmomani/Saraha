using Saraha.Core.Data;
using Saraha.Core.Repository;
using Saraha.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Saraha.Infra.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public bool CreateRole(Role role)
        {
            return roleRepository.CreateRole(role);
        }

        public bool DeleteRole(int? id)
        {
            return roleRepository.DeleteRole(id);
        }

        public List<Role> GetallRoles()
        {
            return roleRepository.GetallRoles();
        }

        public bool UpdateRole(Role role)
        {
            return roleRepository.UpdateRole(role);
        }
    }
}
