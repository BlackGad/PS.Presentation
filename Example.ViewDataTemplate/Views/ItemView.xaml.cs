namespace Example.ViewDataTemplate.Views
{
    /// <summary>
    ///     Interaction logic for ItemView.xaml
    /// </summary>
    public partial class ItemView
    {
        #region Constructors

        public ItemView()
        {
            InitializeComponent();
            ViewModel = new ItemViewModel();
        }

        #endregion

        #region Properties

        public ItemViewModel ViewModel
        {
            get { return DataContext as ItemViewModel; }
            set { DataContext = value; }
        }

        #endregion
    }
}