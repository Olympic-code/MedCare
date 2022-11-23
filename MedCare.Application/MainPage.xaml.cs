using MedCare.Application.Enums;
using MedCare.Application.Views;
using MedCare.Commons.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MedCare.Application
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            // Get the instance of the Title Bar
            var appTitelBar = ApplicationView.GetForCurrentView().TitleBar;
            // Set the color of the Title Bar content
            appTitelBar.BackgroundColor = Colors.Black;
            appTitelBar.ForegroundColor = Colors.White;
            // Set the color of the Title Bar buttons
            appTitelBar.ButtonBackgroundColor = Colors.Black;
            appTitelBar.ButtonForegroundColor = Colors.White;


            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = false;


            this.InitializeComponent();
            AppointmentView.Content = new MedicalProceduresView(MedicalProceduresViewState.APPOIMENT);
            ExamsView.Content = new MedicalProceduresView(MedicalProceduresViewState.EXAM);
            ScheduleView.Content = new ScheduleView();
            TaskView.Content = new TaskView();
            HomeView.Content = new HomeView();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //var userInformations = (Tuple<EnumUserType, int>)e.Parameter;
            //Call the other pages into mainPage frame.
        }
    }
}
