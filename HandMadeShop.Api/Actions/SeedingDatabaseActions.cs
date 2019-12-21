using System.Collections.Generic;
using HandMadeShop.Api.Extensions;
using HandMadeShop.Infrastrucutre.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;

namespace HandMadeShop.Api.Actions
{
    public static class SeedingDatabaseActions
    {
        public static void InitDatabase(this IApplicationBuilder app)
        {
            var docStore = app.ApplicationServices.GetRequiredService<IDocumentStore>();
            docStore.EnsureExists();
        }

        public static void SeedData(this IApplicationBuilder app)
        {
            var docStore = app.ApplicationServices.GetRequiredService<IDocumentStore>();
            docStore.EnsureRolesExist(new List<string> {Roles.Admin, Roles.Moderator});
        }
    }
}