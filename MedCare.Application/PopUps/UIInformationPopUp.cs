using MedCare.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MedCare.Application.PopUps
{
    public class UIInformationPopUp
    {
        public string ScreenName { get; set; }
        public RelayCommand ExitWindowCommand { get; private set; }

        private CornerRadius cornerRadius { get; set; }
        public UIInformationPopUp(Action exitWindowAction)
        {
            cornerRadius = new CornerRadius() { BottomLeft = 10, BottomRight = 10, TopLeft = 10, TopRight = 10 };
            ExitWindowCommand = new RelayCommand(exitWindowAction);
        }
        public async Task showSuccessfulMessage()
        {
            ContentDialog contentDialog = new ContentDialog { Title = $"{ScreenName} Informação".ToUpper(), Content = $"{ScreenName} foi bem sucedida!!", CloseButtonCommand = ExitWindowCommand, CloseButtonText = "Fechar" };
            contentDialog.CornerRadius = cornerRadius;
            contentDialog.Background = new SolidColorBrush(Colors.LightSkyBlue);

            await contentDialog.ShowAsync();

        }
        public async Task showNotSuccessfulMessage()
        {
            ContentDialog contentDialog = new ContentDialog { Title = $"{ScreenName} Informação".ToUpper(), Content = $"{ScreenName} não foi bem sucedida!", CloseButtonCommand = ExitWindowCommand, CloseButtonText = "Fechar" };
            contentDialog.CornerRadius = cornerRadius;
            contentDialog.Background = new SolidColorBrush(Colors.IndianRed);

            await contentDialog.ShowAsync();
        }
        public async Task showNotSuccessfulMessage(string message)
        {
            ContentDialog contentDialog = new ContentDialog { Title = $"{ScreenName} Informação".ToUpper(), Content = message, CloseButtonText = "Fechar" };
            contentDialog.CornerRadius = cornerRadius;
            contentDialog.Background = new SolidColorBrush(Colors.IndianRed);

            await contentDialog.ShowAsync();
        }
    }
}
