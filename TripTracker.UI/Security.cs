using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace TripTracker.UI
{
    public class Security
    {
        public static void Configure(RazorPagesOptions options)
        {
            options.Conventions.AuthorizeFolder("/Account/Manage");
            options.Conventions.AuthorizePage("/Account/Logout");
        }
    }
}
