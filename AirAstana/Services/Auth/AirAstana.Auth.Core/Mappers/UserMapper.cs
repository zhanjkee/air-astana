using AirAstana.Auth.Core.Models;
using AirAstana.Auth.Domain.Entities;
using System.Collections.Generic;

namespace AirAstana.Auth.Core.Mappers
{
    public static class UserMapper
    {
        public static UserInfo ToModel(this UserEntity entity, IEnumerable<string> roles)
        {
            if (entity == null) return null;

            return new UserInfo(entity.Id, entity.UserName, entity.FirstName, entity.LastName, string.Empty, string.Empty, roles);
        }
    }
}
