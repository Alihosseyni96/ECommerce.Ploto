﻿using ECommerce.Ploto.Domain.Models;

namespace ECommerce.Ploto.Application.Queries.User.GetAllUserQuery
{
    public class UserDto
    {
        public string FullName { get;  set; }
        public string PhoneNumber { get;  set; }
        public string HomeNumber { get;  set; }
        public string Address { get;  set; }
        public RolePErmissionDto RolePermisssion { get; set; }
        public UserDto()
        {
            RolePermisssion = new RolePErmissionDto();
        }

    }

    public class RolePErmissionDto
    {
        public string Name { get; set; }
        public PermissionType[] PermissionsType { get; set; }
    }
}
