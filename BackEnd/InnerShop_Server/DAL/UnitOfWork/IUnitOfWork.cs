using DAL.Repositories.IRepositories;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        ICartRepository Cart { get; }
        IFeedbackRepository Feedback { get; }
        IMemberShipRepository MemberShip { get; }
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        IRoleRepository Role { get; }
        ITransactionRepository Transaction { get; }
        IRefreshToken RefreshToken { get; }
        IUserRoleRepository UserRole { get; }
        public void Dispose();
        public Task<bool> SaveChangeAsync();
        public bool SaveChange();
    }
}
