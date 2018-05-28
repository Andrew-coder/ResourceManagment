using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistryManagmentV2.Models.Domain;
using RegistryManagmentV2.Models.Repository;

namespace RegistryManagmentV2.Models
{
    public interface IUnitOfWork
    {
        ResourceRepository ResourceRepository { get; }
        CatalogRepository CatalogRepository { get; }
        UserGroupRepository UserGroupRepository { get; }
        TagRepository TagRepository { get; }
        void Save();
    }
}
