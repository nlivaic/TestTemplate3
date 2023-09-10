using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TestTemplate3.Application.Pipelines;

namespace TestTemplate3.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTestTemplate3ApplicationHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
            services.AddPipelines();

            services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);
        }
    }
}
