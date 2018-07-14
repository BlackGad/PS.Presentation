using System.Windows;
using Example.ViewDataTemplate.Model;
using PS.Presentation;

namespace Example.ViewDataTemplate.Views
{
    /// <summary>
    /// Optional IPayloadContainer inheritance to receive model item from ViewDataTemplate
    /// </summary>
    public class ItemViewModel : DependencyObject,
                                 IPayloadContainer
    {
        #region Property definitions

        public static readonly DependencyProperty PayloadProperty =
            DependencyProperty.Register("Payload", typeof(Item), typeof(ItemViewModel), new PropertyMetadata());

        #endregion

        #region Properties

        public Item Payload
        {
            get { return (Item)GetValue(PayloadProperty); }
            set { SetValue(PayloadProperty, value); }
        }

        object IPayloadContainer.Payload
        {
            get { return Payload; }
            set { Payload = value as Item; }
        }

        #endregion
    }
}