using Data.Interfaces;

namespace Data.Models
{
    public class PastryShop : IPastryShop
    {
        public int Code { get; set; } = 0;

        public string Name { get; set; } = string.Empty;
        
        public IEnumerable<IPastryProduct> Products { get; set; } = new List<IPastryProduct>();

        public void Append(IPastryProduct _product)
        {
            Products.Append(_product);
        }
    }
}
