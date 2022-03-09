using Microsoft.AspNetCore.Authorization;

namespace LivingLab.Web.Controllers
{
    public class AuthorizeLoggedInController : IAuthorizationRequirement
    {
        public AuthorizeLoggedInController()
        {

        }
    }

    public class LoggedIn : AuthorizationHandler<AuthorizeLoggedInController>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public LoggedIn(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            AuthorizeLoggedInController requirement)
        {

            var UserID = _session.GetString("userID");
            if (!string.IsNullOrEmpty(UserID))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
