using BetList.Core.Builder;
using BetList.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Web.Compilation;

namespace BetList.Core
{
    public class BetListInstanceGetter
    {
        public IBuilder GetChoiceBuilderInstance(string baseBuilderId)
        {
            string typeName = string.Join(null, new string[] { "BetList.Product.Builder", ".Choice", baseBuilderId, "Builder" });
            Type type = GetBetListAssemblies(typeName);

            return Activator.CreateInstance(type) as IBuilder;
        }

        public IElement GetChoiceElementInstance(ITicket ticket, ITicketHelper ticketHelper, string baseElementId)
        {
            string typeName = string.Join(null, new string[] { "BetList.Product.Element", ".Choice", baseElementId, "Element" });
            Type type = GetBetListAssemblies(typeName);

            if (type == null)
            {
                return new Element();
            }

            return Activator.CreateInstance(type, ticket, ticketHelper) as IElement;
        }

        public IBuilder GetStatusBuilderInstance(string baseBuilderId)
        {
            string typeName = string.Join(null, new string[] { "BetList.Product.Builder", ".Status", baseBuilderId, "Builder" });
            Type type = GetBetListAssemblies(typeName);

            return Activator.CreateInstance(type) as IBuilder;
        }

        public IElement GetStatusElementInstance(ITicket ticket, ITicketHelper ticketHelper, string baseElementId)
        {
            string typeName = string.Join(null, new string[] { "BetList.Product.Element", ".Status", baseElementId, "Element" });
            Type type = GetBetListAssemblies(typeName);

            if (type == null)
            {
                return new Element();
            }

            return Activator.CreateInstance(type, ticket, ticketHelper) as IElement;
        }



        private Type GetBetListAssemblies(string typeName)
        {
            ObjectCache cache = MemoryCache.Default;

            var assemblies = (List<Assembly>)cache["BetList.Core.CacheKey"];

            if (assemblies == null || !assemblies.Any())
            {
                try
                {
                    assemblies = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();
                }
                catch
                {
                    assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
                }

                CacheItemPolicy policy = new CacheItemPolicy();
                policy.Priority = CacheItemPriority.NotRemovable;

                assemblies = assemblies.Where(x => x.FullName.StartsWith("BetList.", StringComparison.InvariantCulture)).ToList();

                cache.Set("BetList.Core.CacheKey", assemblies, policy);
            }

            foreach (var assembly in assemblies)
            {
                Type type = Type.GetType(typeName + ", " + assembly);

                if (type != null)
                {
                    return type;
                }
            }

            return null;
        }
    }
}