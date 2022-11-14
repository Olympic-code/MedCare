using MedCare.Commons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MedCare.Application.Services
{
    public class ScreenControl : IScreenControl
    {
        public void NavigateTo(Tuple<EnumUserType, int> userInfomation)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(MainPage), userInfomation);
        }
    }
}
