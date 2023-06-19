namespace coreapi.BusinessObjects.NonDC
{
    public class PhoneUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
