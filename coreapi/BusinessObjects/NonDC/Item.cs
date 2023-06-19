namespace coreapi.BusinessObjects.NonDC
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public decimal Cost { get; set; } = decimal.Zero;
        public decimal QtyCount { get; set; } = decimal.Zero;
        public decimal QtyC2 { get; set; } = decimal.Zero;

        public decimal TotalPrice
        {
            get
            {
                return QtyCount * Price;
            }
        }
        public decimal TotalCost
        {
            get
            {
                return QtyCount * Cost;
            }
        }
    }
}
