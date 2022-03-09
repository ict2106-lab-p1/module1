using System.Diagnostics;

using Microsoft.AspNetCore.Authorization;

namespace LivingLab.Web
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
        private ISession _session
        {
            get
            {
                Debug.Assert(_httpContextAccessor.HttpContext != null, "_httpContextAccessor.HttpContext != null");
                return _httpContextAccessor.HttpContext.Session;
            }
        }

        public LoggedIn(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            AuthorizeLoggedInController requirement)
        {

            var UserID = _session.GetString("UserID");
            if (!string.IsNullOrEmpty(UserID))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
