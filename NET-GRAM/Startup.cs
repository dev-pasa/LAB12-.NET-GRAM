﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NET_GRAM.Data;
using NET_GRAM.Models.Interfaces;
using NET_GRAM.Models.Services;

namespace NET_GRAM
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            //var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            //builder.AddUserSecrets<Startup>();
            //Configuration = builder.Build();
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<PostsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<PostsDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:ProductionConnection"]));
            //services.AddDbContext<PostsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BlobConnectionString")));
            services.AddScoped<IGram, PostsManager>();
            //services.AddScoped<IComment, CommentManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
