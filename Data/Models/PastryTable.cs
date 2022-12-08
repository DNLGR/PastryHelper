namespace Data.Models
{
    public class PastryTable : IPastryTable
    {
        #region Param
        public DateOnly TableDate { get; set; }

        public IEnumerable<IPastryShop> PastryShops { get; set; }
        #endregion

        #region Ctor
        public PastryTable()
        {
            TableDate = DateOnly.FromDateTime(DateTime.Now);

            PastryShops = new List<PastryShop>();
        }

        public PastryTable(DateOnly _date, IEnumerable<PastryShop> _pastryShops)
        {
            TableDate = _date;

            PastryShops = _pastryShops;
        }
        #endregion

        #region Methods
        public void Append(PastryShop _obj)
        {
            if (_obj == null)
            {
                throw new ArgumentException("It is not possible to add an empty product", nameof(_obj));
            }

            if (PastryShops.Contains(_obj))
            {
                throw new ArgumentException("The product is already on the list", nameof(_obj));
            }

            PastryShops = PastryShops.Append(_obj);
        }

        public void Remove(int _code)
        {
            if (_code < 0)
            {
                throw new ArgumentException("Cannot delete this collection item", nameof(_code));
            }

            PastryShops = PastryShops.Where(x => x.Code != _code).ToList();
        }

        public void Append(IPastryShop element)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
