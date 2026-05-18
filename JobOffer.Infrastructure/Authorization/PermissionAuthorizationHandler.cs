
namespace JobOffer.Infrastructure.Authorization
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<Permission>
    {

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, Permission requirement)
        {
            var permission = context.User.Claims
                                 .Where(c => c.Type == "Permission")
                                 .Select(c => c.Value)
                                 .ToHashSet();

            if (permission.Any())
                context.Succeed(requirement);

            return Task.CompletedTask;
               
        }

    }
}
