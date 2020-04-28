using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.BisinessLogic.Books;
using WebApi.Interfaces.Cache;
using WebApi.Interfaces.Publish;
using WebApi.Services.Cache;
using WebApi.Services.Publish;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddScoped<IPublisher>(s => new Publisher(_configuration.GetConnectionString("rabbit")));
            services.AddScoped<ICache>(s => new Cache(_configuration.GetConnectionString("redis")));
            services.AddScoped<GetBookInfoRequestHandler>();
            services.AddScoped<CreateBookRequestHandler>();

            //services.AddDistributedRedisCache(option =>
            //{
            //    option.Configuration = Configuration.GetConnectionString("redisForTest");
            //});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}