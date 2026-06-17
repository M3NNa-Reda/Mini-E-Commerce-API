namespace Mini_E_Commerce_API.Models
{
    
    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Admin or Customer
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
