using coreapi.BusinessObjects.NonDC;

namespace coreapi.BusinessObjects.Count
{
    public class InventoryItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal QtyCount { get; set; }
        public PhoneUser? PhoneUser { get; set; }
    }
}
