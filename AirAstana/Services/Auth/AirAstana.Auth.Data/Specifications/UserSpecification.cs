using AirAstana.Auth.Domain.Entities;

namespace AirAstana.Auth.Data.Specifications
{
    public sealed class UserSpecification : BaseSpecification<UserEntity>
    {
        public UserSpecification(string id) : base(u => u.Id == id)
        {
            AddInclude(u => u.RefreshTokens);
        }
    }
}
