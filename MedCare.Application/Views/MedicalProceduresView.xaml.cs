using MedCare.Application.Enums;
using MedCare.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MedCare.Application.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MedicalProceduresView : Page
    {
        public MedicalProceduresViewModel ViewModel => (MedicalProceduresViewModel)DataContext;
        public MedicalProceduresViewState TypeFrame { get; set; }
        public MedicalProceduresView(MedicalProceduresViewState typeFrame)
        {
            this.InitializeComponent();
            TypeFrame = typeFrame;
            DataContext = new MedicalProceduresViewModel(typeFrame);
            if (ViewModel.MedicalProceduresNotDone.Count != 0)
            {
                NothingTextDone.Visibility = Visibility.Collapsed;
            }
            if (ViewModel.MedicalProceduresDone.Count != 0)
            {
                NothingTextNotDone.Visibility = Visibility.Collapsed;
            }


            if(typeFrame == MedicalProceduresViewState.APPOIMENT)
            {
                AppoimentsFrameTitle.Visibility = Visibility.Visible;
                ExamsFrameTitle.Visibility = Visibility.Collapsed;
                
                CompleteAppoimentsFrameTitle.Visibility = Visibility.Visible;
                CompleteExamsFrameTitle.Visibility = Visibility.Collapsed;

                IncompleteAppoimentsFrameTitle.Visibility = Visibility.Visible;
                IncompleteExamsFrameTitle.Visibility = Visibility.Collapsed;

            }
            else
            {
                AppoimentsFrameTitle.Visibility = Visibility.Collapsed;
                ExamsFrameTitle.Visibility = Visibility.Visible;

                CompleteAppoimentsFrameTitle.Visibility = Visibility.Collapsed;
                CompleteExamsFrameTitle.Visibility = Visibility.Visible;

                IncompleteAppoimentsFrameTitle.Visibility = Visibility.Collapsed;
                IncompleteExamsFrameTitle.Visibility = Visibility.Visible;

            }
        }

        private void AddNewAppoimentBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AddMedicalProcedureControl.Visibility == Visibility.Visible)
                AddMedicalProcedureControl.Visibility = Visibility.Collapsed;
            else
                AddMedicalProcedureControl.Visibility = Visibility.Visible;
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            DataContext = new MedicalProceduresViewModel(TypeFrame);
        }

       
    }
}
