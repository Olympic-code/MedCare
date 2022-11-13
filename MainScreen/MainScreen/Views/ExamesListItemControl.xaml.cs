using System;

using MainScreen.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MainScreen.Views
{
    public sealed partial class ExamesListItemControl : UserControl
    {
        public SampleOrder Item
        {
            get { return (SampleOrder)GetValue(ItemProperty); }
            set { SetValue(ItemProperty, value); }
        }

        public static readonly DependencyProperty ItemProperty = DependencyProperty.Register(nameof(Item), typeof(SampleOrder), typeof(ExamesListItemControl), new PropertyMetadata(null, OnItemPropertyChanged));

        public ExamesListItemControl()
        {
            InitializeComponent();
        }

        private static void OnItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
