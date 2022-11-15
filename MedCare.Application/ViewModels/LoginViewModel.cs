using MedCare.Application.Services;
using MedCare.Application.ViewModels.Base;
using MedCare.Commons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedCare.Application.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Attributes
        private readonly IScreenControl screenControl;
        private readonly IAuthenticationService authenticationService;
        #endregion


        #region Properties
        private string _userEmail;
        public string UserEmail
        {
            get => _userEmail;
            set
            {
                _userEmail = value.ToLower();
                OnPropertyChanged(nameof(UserEmail));
            }

        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        private bool _errorMessageIsVisible;
        public bool ErrorMessageIsVisible
        {
            get => _errorMessageIsVisible;
            set
            {
                _errorMessageIsVisible = value;
                OnPropertyChanged(nameof(ErrorMessageIsVisible));
            }
        }
        #endregion

        public LoginViewModel()
        {
            screenControl = new ScreenControl();
            authenticationService = new AuthenticationService();
        }

        public async void ExecuteLoginCommand()
        {
            ErrorMessageIsVisible = false;
            try
            {
                Tuple<EnumUserType, int> userInfomations = await authenticationService.ValidateLogin(UserEmail, Password);
                screenControl.NavigateToMainPage(userInfomations);
            }
            catch(Exception ex)
            {
                //Corrigir mensagem de erro
                ErrorMessage = ex.Message;
                ErrorMessageIsVisible = true;
            }
        }

    }
}
