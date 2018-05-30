﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RegistryManagmentV2.Models.Domain;

namespace RegistryManagmentV2.Models.Repository
{
    public class ResourceRepository : Repository<Resource>
    {
        public ResourceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Resource> FindRootCatalogs()
        {
            return Context.Resources
                .Where(resource => resource.Catalog == null)
                .Where(resource => resource.ResourceStatus == ResourceStatus.Approved)
                .ToList();
        }

        public List<Resource> GetChildCatalogsByUserGroup(long catalogId)
        {
            return Context.Resources
                .Where(resource => resource.CatalogId == catalogId)
                .Where(resource => resource.ResourceStatus == ResourceStatus.Approved)
                .ToList();
        }

        public IList<Resource> GetResourcesByTagsOrderedByPriority(IList<string> tags)
        {
            return Context.Resources
                .Where(resource => resource.Tags.Select(res => res.TagValue).Intersect(tags).Any())
                .OrderBy(resource => resource.Priority).ToList();
        }
    }
}