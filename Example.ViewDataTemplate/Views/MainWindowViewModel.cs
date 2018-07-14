using Example.ViewDataTemplate.Model;

namespace Example.ViewDataTemplate.Views
{
    public class MainWindowViewModel
    {
        #region Constructors

        public MainWindowViewModel()
        {
            ItemsSource = new[]
            {
                new Item
                {
                    Name = "Root 1",
                    SubItems = new[]
                    {
                        new Item
                        {
                            Name = "Root 1 -> Sub 1"
                        },
                        new Item
                        {
                            Name = "Root 1 -> Sub 2"
                        }
                    }
                },
                new Item
                {
                    Name = "Root 2",
                    SubItems = new[]
                    {
                        new Item
                        {
                            Name = "Root 2 -> Sub 1"
                        },
                        new Item
                        {
                            Name = "Root 2 -> Sub 2"
                        }
                    }
                },
            };
        }

        #endregion

        #region Properties

        public Item[] ItemsSource { get; }

        #endregion
    }
}