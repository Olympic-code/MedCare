using MedCare.Application.Views;
using MedCare.Commons.Entities;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MedCare.Application.Services
{
    public class ScreenControl : IScreenControl
    {
        public void NavigateToMainPage(Tuple<EnumUserType, int> userInfomation)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage), userInfomation);
        }

        public void NavigateToLoginView()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(LoginView));
        }

        public void NavigateToRegistrationView()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(RegistrationView));
        }
    }
}
