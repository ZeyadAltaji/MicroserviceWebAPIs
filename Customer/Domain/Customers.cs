namespace Customer.Domain
{
    public class Customers
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public byte[] password { get; set; }
        public byte[] PasswordKey { get; set; }
    }
}
