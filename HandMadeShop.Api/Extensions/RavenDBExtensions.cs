using System.Collections.Generic;
using System.Linq;
using HandMadeShop.Core.DomainEntities;
using Raven.Client.Documents;
using Raven.Client.Exceptions.Database;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using Raven.Identity;

namespace HandMadeShop.Api.Extensions
{
    public static class RavenExtensions
    {
        public static IDocumentStore EnsureExists(this IDocumentStore store)
        {
            try
            {
                using (var dbSession = store.OpenSession())
                {
                    dbSession.Query<User>().Take(0).ToList();
                }
            }
            catch (DatabaseDoesNotExistException)
            {
                store.Maintenance.Server.Send(new CreateDatabaseOperation(
                    new DatabaseRecord
                    {
                        DatabaseName = store.Database
                    }));
            }

            return store;
        }

        public static IDocumentStore EnsureRolesExist(this IDocumentStore docStore, List<string> roleNames)
        {
            using (var dbSession = docStore.OpenSession())
            {
                var roleIds = roleNames.Select(r => "IdentityRoles/" + r);
                var roles = dbSession.Load<IdentityRole>(roleIds);
                foreach (var idRolePair in roles)
                    if (idRolePair.Value == null)
                    {
                        var id = idRolePair.Key;
                        var roleName = id.Replace("IdentityRoles/", string.Empty);
                        dbSession.Store(new IdentityRole(roleName), id);
                    }

                if (roles.Any(i => i.Value == null)) dbSession.SaveChanges();
            }

            return docStore;
        }
    }
}