
namespace JobOffer.Infrastructure.Authorization
{
    public class Permission : IAuthorizationRequirement
    {

        public string permission { get; }
        public Permission(string permission)
        {
            this.permission = permission;
        }

    }
}
