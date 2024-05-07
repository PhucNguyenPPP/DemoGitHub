namespace Common.DTO
{
    public class LocalUserDTO
    {
        public Guid UserId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double MoneySpent { get; set; }
        public string ShopPhone { get; set; }
        public string ShopAddress { get; set; }
        public string ShopDescription { get; set; }
        public bool Status { get; set; }

    }
}
