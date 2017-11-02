using ir.ankasoft.infrastructure;

namespace ir.ankasoft.entities.Repositories
{
    public interface ICommunicationRepository : IRepository<Communication, long>
    {
        void changePrimary(long id, bool status);
    }
}