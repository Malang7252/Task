using AutoMapper;
using Task.DAL.Repositories.Accounts;
using Task.DAL.Repositories.Addresses;
using Task.DAL.Repositories.Clients;
using Task.GenericRepository;
using Task.Service.Mappings;
using Task.Service.Services.Accounts;
using Task.Service.Services.Addresses;
using Task.Service.Services.Authentications;
using Task.Service.Services.Clients;

namespace Task.API.Extensions
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IClientService, ClientService>();

            // Register memory cache
            services.AddMemoryCache();
        }


        public static void AddRepos(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();


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
