namespace DAL.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public double MoneySpent { get; set; }
        public string? ShopPhone { get; set; }
        public string? ShopAddress { get; set; }
        public string? ShopDescription { get; set; }
        public bool Status { get; set; }
        public string? ResetPassToken { get; set; }
        public virtual MemberShip MemberShip { get; set; }
        public Guid MemberShipId { get; set; }
        public virtual ICollection<ShippingServiceSeller> ShippingServiceSellers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<VoucherUser> VoucherUsers { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
