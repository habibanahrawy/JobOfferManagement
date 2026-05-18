
using System.Security.Claims;

namespace JobOffer.Infrastructure.ServicesImplementation
{
    public class TenantService : ITenantService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentTenant()
        {
            
            var tenantId = _httpContextAccessor.HttpContext?.User.FindFirstValue("TenantId");
            return tenantId ?? string.Empty;
        }
    }
}
