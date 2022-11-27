namespace Data.Models
{
    public class PastryProduct : IPastryProduct
    {
        private int _code;
        public int Code
        {
            get => _code;
            set
            {
                if (value > 0 && value > int.MaxValue)
                {
                    throw new ArgumentException("It is not correct code for product", nameof(Code));
                }

                _code = value;

                _name = $"Shop {_code}";
            }
        }


        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("It is not correct name for product", nameof(Name));
                }

                _name = value;
            }
        }


        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                if (value > 1 || value >= int.MaxValue)
                {
                    throw new ArgumentException("It is not correct count for product", nameof(Count));
                }

                _count = value;
            }
        }
    }
}
