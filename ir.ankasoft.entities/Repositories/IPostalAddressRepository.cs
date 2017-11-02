using ir.ankasoft.infrastructure;

namespace ir.ankasoft.entities.Repositories
{
    public interface IPostalAddressRepository : IRepository<PostalAddress, long>
    {
        void changePrimary(long id, bool status);
    }
}