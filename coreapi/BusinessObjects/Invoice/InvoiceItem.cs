namespace coreapi.BusinessObjects.Invoice
{
    public class InvoiceItem
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal Qty { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public decimal Cost { get; set; } = 0;

        public decimal TotalPrice { get { return Qty * Price; } }
        public decimal TotalCost { get { return Qty * Cost; } }
    }
}
