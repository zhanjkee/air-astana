using AirAstana.Auth.Core.Models;
using AirAstana.Auth.Domain.Entities;

namespace AirAstana.Auth.Core.Mappers
{
    public static class UserMapper
    {
        public static UserInfo ToModel(this UserEntity entity)
        {
            if (entity == null) return null;

            return new UserInfo(entity.FirstName, entity.Id, entity.LastName, entity.UserName, string.Empty, string.Empty, new string[0]);
        }
    }
}
