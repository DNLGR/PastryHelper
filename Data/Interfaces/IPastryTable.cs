namespace Data.Interfaces
{
    public interface IPastryTable
    {
        public DateOnly TableDate { get; set; }

        public IEnumerable<IPastryShop> PastryShops { get; set; }

        public int CommonProductsCount { get => PastryShops?.Sum(x => x.Products.Sum(z => z.Count)) ?? 0; }

        public void Append(IPastryShop element);

        public void Remove(int code);
    }
}
