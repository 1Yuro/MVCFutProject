using Hafta10.Web.Middlewares;
namespace Hafta10.Web.Extensions
{
    public static class mainExtension
    {
        public static IApplicationBuilder mainEx(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<mainMiddlewares>();
        }
    }
}
