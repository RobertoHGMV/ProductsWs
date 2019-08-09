namespace ProdctsWs.Domain.Models
{
    public class Product
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; private set; }

        public void CalcTotal()
        {
            Total = Quantity * Price;
        }
    }
}
