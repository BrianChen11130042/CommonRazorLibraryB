using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.FeaturePackage.UserPack.Application;
using CommonRazorLibraryB.FeaturePackage.UserPack.EFModel;
using CommonRazorLibraryB.FeaturePackage.UserPack.Tool;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BitzArt.Blazor.Cookies;

namespace CommonRazorLibraryB.FeaturePackage.UserPack.Extension
{
    public static class UserExtension
    {
        public static IHostApplicationBuilder AddUserFeaturePack(this IHostApplicationBuilder builder, string connectionString)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

            builder.Services.AddDbContext<UserManageDbContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddDataProtection();
            builder.AddBlazorCookies();

            builder.Services.AddSingleton<AuthTool>();
            builder.Services.AddScoped<AuthApplication>();
            builder.Services.AddSingleton<UserManageApplication>();

            return builder;
        }
    }
}
