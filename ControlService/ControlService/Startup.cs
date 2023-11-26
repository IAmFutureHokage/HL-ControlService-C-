﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ControlService.Models.Repositories;
using ControlService.Protos;
using ControlService.Models.Entities;

namespace ControlService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Настройка подключения к базе данных PostgreSQL
            services.AddSingleton<HControlServiceDbContext>(_ =>
        new HControlServiceDbContext("Host=localhost;Port=5432;Database=HControlService;Username=postgres;Password=321@Adc;"));
            services.AddScoped<Repository<HydrologyControl>>();
            services.AddScoped<HydrologyControlServiceImpl>();
            services.AddGrpc();
            //services.AddGrpc(options => { options.EnableDetailedErrors = true; }) ;
            var serviceProvider = services.BuildServiceProvider();
            var dbContext = serviceProvider.GetService<HControlServiceDbContext>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGrpcService<HydrologyControlService>();
                endpoints.MapGrpcService<HydrologyControlServiceImpl>();
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello, this is an empty page!");
                //});
            });
        }
    }
}
