using System.Xml.Serialization;

namespace ProductsWs.WS.ViewModels
{
    [XmlRoot(ElementName = "ProductModel")]
    public class ProductModel
    {
        [XmlElement(ElementName = "ItemCode")]
        public string ItemCode { get; set; }
        [XmlElement(ElementName = "ItemName")]
        public string ItemName { get; set; }
        [XmlElement(ElementName = "Quantity")]
        public int Quantity { get; set; }
        [XmlElement(ElementName = "Price")]
        public decimal Price { get; set; }
        [XmlElement(ElementName = "Total")]
        public decimal Total { get; set; }
    }
}