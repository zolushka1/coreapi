using coreapi.BusinessObjects.Types;

namespace coreapi.BusinessObjects.Invoice
{
    public class Invoice
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public InvoiceType InvoiceType { set; get; }
        public int Attribute { set; get; }


        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime InvoiceDate { get; set; }


        public Decimal TotalPrice { get { return invoiceItems.Sum(t=>t.TotalPrice); } }
        public Decimal TotalCost { get { return invoiceItems.Sum(t => t.TotalCost); } }

        public Decimal ItemCount { get { return invoiceItems.Count(); } }
        public Decimal ItemQtyCount { get { return invoiceItems.Sum(t=>t.Qty); } }

        public IList<InvoiceItem> invoiceItems { get; set; }
    }
}
