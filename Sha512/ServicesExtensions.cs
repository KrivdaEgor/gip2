using Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Sha512
{
    public static class ServicesExtensions
    {
        public static void AddSha512Hashing(this IServiceCollection services)
        {
            services.AddTransient<IHashingService, Sha512HashingService>();
        }
    }
}
