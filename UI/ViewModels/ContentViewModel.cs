namespace UI.ViewModels
{
    internal class ContentViewModel : ViewModelBase
    {
        #region Var
        public IPastryTable PastryTable { get; private set; }

        private JsonParser _parser;
        #endregion

        #region Ctor
        public ContentViewModel()
        {
            _parser = new JsonParser();

            PastryTable = new PastryTable();
        }
        #endregion

        #region Commands
        public ICommand HeaderButtonCloseCommand
        {
            get => new DelegateCommand(() =>
            {
                System.Windows.Application.Current.MainWindow.Close();
            });
        }

        public ICommand HeaderButtonWindowStateCommand
        {
            get => new DelegateCommand(() =>
            {
                System.Windows.Application.Current.MainWindow.WindowState =
                    System.Windows.Application.Current.MainWindow.WindowState == System.Windows.WindowState.Normal ?
                        System.Windows.WindowState.Maximized : System.Windows.WindowState.Normal;
            });
        }

        public ICommand HeaderButtonMinimizeCommand
        {
            get => new DelegateCommand<string>(x =>
            {
                System.Windows.Application.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
            });
        }
        public ICommand ShopListButtonAddCommand
        {
            get => new DelegateCommand(() =>
            {
                IPastryShop element = new PastryShop()
                {
                    Code = PastryTable?.PastryShops.Count() + 1 ?? 1,

                    Products = new List<PastryProduct>()
                };

                PastryTable.Append(element);
            });
        }

        public ICommand ShopListButtonRemoveCommand
        {
            get => new DelegateCommand<int>(x =>
            {
                PastryTable.Remove(x);
            });
        }

        public ICommand ReadTableCommand
        {
            get => new DelegateCommand<string>(x =>
            {
                var obj = _parser.Read(x);

                if (obj == null)
                {
                    return;
                }

                PastryTable = new PastryTable() { TableDate = obj.TableDate, PastryShops = obj.PastryShops };
            });
        }

        public ICommand WriteTableCommand
        {
            get => new DelegateCommand<string>(x =>
            {
                _parser.Write(PastryTable ?? new PastryTable(), x);
            });
        }
        #endregion
    }
}
