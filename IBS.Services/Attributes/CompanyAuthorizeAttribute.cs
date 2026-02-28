using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IBS.Services.Attributes
{
    public class CompanyAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _company;

        public CompanyAuthorizeAttribute(string company)
        {
            _company = company;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var companyClaim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Company")?.Value;

            // During consolidation, allow both Filpride and MMSI users to access the resources
            bool isAuthorized = string.Equals(companyClaim, _company, StringComparison.OrdinalIgnoreCase);
            
            if (!isAuthorized)
            {
                if ((_company == "MMSI" || _company == "Filpride") && 
                    (companyClaim == "MMSI" || companyClaim == "Filpride"))
                {
                    isAuthorized = true;
                }
            }

            if (!isAuthorized)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
