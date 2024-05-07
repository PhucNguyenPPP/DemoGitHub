using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class InnerContext : DbContext
    {
        public InnerContext(DbContextOptions<InnerContext> option) : base(option) { }

        #region Entities
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<MemberShip> Memberships { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ShippingService> ShippingServices { get; set; }
        public DbSet<ShippingServiceCity> ShippingServiceCities { get; set; }
        public DbSet<ShippingServiceSeller> ShippingServiceSellers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherUser> VoucherUsers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Constraint
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(c => c.CardId);
                entity.Property(c => c.CardId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.CategoryId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.HasKey(c => c.ChatId);
                entity.Property(c => c.ChatId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(f => f.FeedbackId);
                entity.Property(f => f.FeedbackId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<MemberShip>(entity =>
            {
                entity.HasKey(m => m.MemberShipId);
                entity.Property(m => m.MemberShipId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId);
                entity.Property(o => o.OrderId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.ProductId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(r => r.RoleId);
                entity.Property(r => r.RoleId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ShippingService>(entity =>
            {
                entity.HasKey(s => s.SsId);
                entity.Property(s => s.SsId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ShippingServiceCity>(entity =>
            {
                entity.HasKey(s => s.SsCityId);
                entity.Property(s => s.SsCityId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ShippingService>(entity =>
            {
                entity.HasKey(s => s.SsId);
                entity.Property(s => s.SsId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.TransactionId);
                entity.Property(t => t.PaymentMethod).HasMaxLength(20).IsRequired();
                entity.Property(t => t.Status).IsRequired();
                entity.Property(t => t.TransactionInfo).HasMaxLength(50).IsRequired();
                entity.Property(t => t.TransactionDate).IsRequired();
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.HasKey(v => v.VoucherId);
                entity.Property(v => v.VoucherId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(v => v.RefreshTokenId);
                entity.Property(v => v.RefreshTokenId).ValueGeneratedOnAdd();
            });
            #endregion

            #region 1-1
            modelBuilder.Entity<Order>()
                .HasOne(cp => cp.Transaction)
                .WithOne(t => t.Order)
                .HasForeignKey<Transaction>(t => t.TransactionId);

            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.RefreshTokens)
            //    .WithOne(r => r.User)
            //    .HasForeignKey<RefreshToken>(r=> r.UserId).OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region M_To_M_Relationship

            modelBuilder.Entity<CartProduct>()
                .HasKey(cp => new { cp.CartId, cp.ProductId });
            modelBuilder.Entity<CartProduct>()
                .HasOne(cp => cp.Cart)
                .WithMany(t => t.CartProducts)
                .HasForeignKey(cp => cp.CartId);
            modelBuilder.Entity<CartProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(o => o.CartProducts)
                .HasForeignKey(cp => cp.ProductId);


            modelBuilder.Entity<OrderDetail>()
                .HasKey(cp => new { cp.OrderId, cp.ProductId});
            modelBuilder.Entity<OrderDetail>()
                .HasOne(cp => cp.Order)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(cp => cp.OrderId);
            modelBuilder.Entity<OrderDetail>()
                .HasOne(cp => cp.Product)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(cp => cp.ProductId);

            modelBuilder.Entity<UserRole>()
                .HasKey(cp => new { cp.UserId, cp.RoleId});
            modelBuilder.Entity<UserRole>()
                .HasOne(cp => cp.User)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(cp => cp.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(cp => cp.Role)
                .WithMany(o => o.UserRoles)
                .HasForeignKey(cp => cp.RoleId);

            modelBuilder.Entity<VoucherUser>()
                .HasKey(cp => new { cp.VoucherId, cp.UserId});
            modelBuilder.Entity<VoucherUser>()
                .HasOne(cp => cp.Voucher)
                .WithMany(t => t.VoucherUsers)
                .HasForeignKey(cp => cp.VoucherId);
            modelBuilder.Entity<VoucherUser>()
                .HasOne(cp => cp.User)
                .WithMany(o => o.VoucherUsers)
                .HasForeignKey(cp => cp.UserId);

            modelBuilder.Entity<ShippingServiceSeller>()
                .HasKey(cp => new { cp.SsId, cp.UserId });
            modelBuilder.Entity<ShippingServiceSeller>()
                .HasOne(cp => cp.Users)
                .WithMany(t => t.ShippingServiceSellers)
                .HasForeignKey(cp => cp.UserId);
            modelBuilder.Entity<ShippingServiceSeller>()
                .HasOne(cp => cp.ShippingService)
                .WithMany(o => o.ShippingServiceSellers)
                .HasForeignKey(cp => cp.SsId);

            #endregion
        }
    }
}