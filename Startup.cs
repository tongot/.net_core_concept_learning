using System;

using AutoMapper;
using learn_net_core.Models;
using learn_net_core.services.CharacterService;
using learn_net_core.services.StudentService;
using learn_net_core.services.UserAccountService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace learn_net_core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CharacterContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("CharacterConnection")
            ));
            services.AddIdentity<UserAccount, IdentityRole>()
                  .AddEntityFrameworkStores<CharacterContext>()
                  .AddDefaultTokenProviders();
            services.AddAuthentication("OAuth").AddJwtBearer("OAuth", config =>
            {

            });
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUserAccountService, UserAccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
