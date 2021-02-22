using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataManager.Contracts.V1.DTO.Auth
{
    public class UserRoleRequest
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
