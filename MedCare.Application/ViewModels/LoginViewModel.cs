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

        private SecureString _password;
        public SecureString Password
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

        #endregion

        public LoginViewModel()
        {
            
        }

        public void ExecuteLoginCommand()
        {
            var email = UserEmail;
            var password = Password;
        }

    }
}
