using AutoMapper;
using Task.Service.Mappings;
using Task.Service.Services.Authentications;

namespace Task.API.Extensions
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }


        public static void AddRepos(this IServiceCollection services)
        {

        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            // Manually configure AutoMapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile()); // Register your profiles here
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper); // Register IMapper as singleton
        }
    }
}
