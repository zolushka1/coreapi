using coreapi.BusinessObjects.NonDC;

namespace coreapi.BusinessObjects.Count
{
    public class Inventory
    {
        public string Id { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<PhoneUser>? phoneUsers { get; set; }
        public IList<InventoryItem>? InventoryItems { get; set;}
    }
}
