using RegistryManagmentV2.Models.Repository;

namespace RegistryManagmentV2.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ApplicationDbContext Context = new ApplicationDbContext();
        public ResourceRepository ResourceRepository { get; } = new ResourceRepository(Context);
        public CatalogRepository CatalogRepository { get; } = new CatalogRepository(Context);
        public UserGroupRepository UserGroupRepository{ get; } = new UserGroupRepository(Context);
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}