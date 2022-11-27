namespace Data.Interfaces
{
    public interface IPastryShop
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public IEnumerable<IPastryProduct> Products { get; set; }
    }
}
