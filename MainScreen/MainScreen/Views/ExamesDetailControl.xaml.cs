using MainScreen.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MainScreen.Views
{
    public sealed partial class ExamesDetailControl : UserControl
    {
        public SampleOrder SelectedItem
        {
            get { return GetValue(SelectedItemProperty) as SampleOrder; }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(nameof(SelectedItem), typeof(SampleOrder), typeof(ExamesDetailControl), new PropertyMetadata(null, OnSelectedItemPropertyChanged));

        public ExamesDetailControl()
        {
            InitializeComponent();
        }

        private static void OnSelectedItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ExamesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
