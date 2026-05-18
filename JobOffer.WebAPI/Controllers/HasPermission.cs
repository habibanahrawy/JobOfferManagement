namespace JobOffer.WebAPI.Controllers
{
    public class HasPermission : AuthorizeAttribute
    {
        public HasPermission(string permission) : base(permission)
        {
        }
    }
}
