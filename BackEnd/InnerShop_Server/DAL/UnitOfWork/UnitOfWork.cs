using DAL.Data;
using DAL.Entities;
using DAL.Repositories;
using DAL.Repositories.IRepositories;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InnerContext _context;

        public UnitOfWork(InnerContext context)
        {
            _context = context;
            User = new UserRepository(_context);
            Cart = new CartRepository(_context);
            Feedback = new FeedbackRepository(_context);
            MemberShip = new MemberShipRepository(_context);
            Order = new OrderRepository(_context);
            Product = new ProductRepository(_context);
            Role = new RoleRepository(_context);
            Transaction = new TransactionRepository(_context);
            RefreshToken = new RefreshTokenRepository(_context);
            UserRole = new UserRoleRepository(_context);
    
        }

        public IUserRepository User { get; private set; }

        public ICartRepository Cart { get; private set; }

        public IFeedbackRepository Feedback { get; private set; }

        public IMemberShipRepository MemberShip { get; private set; }

        public IOrderRepository Order { get; private set; }

        public IProductRepository Product { get; private set; }

        public IRoleRepository Role { get; private set; }

        public ITransactionRepository Transaction { get; private set; }

        public IRefreshToken RefreshToken { get; private set; }

        public IUserRoleRepository UserRole { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool SaveChange()
        {
            return _context.SaveChanges() > 0 ;
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0 ;
        }
    }
}
