﻿using GatePass.Core.Identity;
using GatePass.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GatePass.Infrastructure;
public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString)
    {
        //services.AddDbContext<AppDbContext>(options =>
        //    options.UseSqlite(connectionString)); // will be created in web project root

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, serverVersion));

        services
            .AddDefaultIdentity<AppUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();
    }
}
