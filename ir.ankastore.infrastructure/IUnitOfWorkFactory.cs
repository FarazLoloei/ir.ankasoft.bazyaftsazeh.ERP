namespace ir.ankasoft.infrastructure
{
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates a new instance of a unit of work
        /// </summary>
        IUnitOfWork Create();

        /// <summary>
        /// Creates a new instance of a unit of work
        /// </summary>
        /// <param name="forceNew">When true, clears out any existing in-memory data store / cache first.</param>
        IUnitOfWork Create(bool forceNew);
    }
}