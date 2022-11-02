using System;
using System.Security;
using System.Windows.Input;

namespace MedCare.ViewModels
{
    public class ViewModelLogin : ViewModelBase
    {
        #region Properties
        public ICommand LoginCommand { get; private set; }
        public ICommand ShowPasswordCommand { get; private set; }
        public ICommand RecoverPasswordCommand { get; private set; }
        public ICommand RememberPasswordCommand { get; private set; }

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

        //To Do State design patterns
        private bool _isViewVisible = true;
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        #endregion

        public ViewModelLogin()
        {
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            ShowPasswordCommand = new ViewModelCommand(ExecuteShowPasswordCommand, CanExecuteShowPasswordCommand);
            RecoverPasswordCommand = new ViewModelCommand(ExecuteRecoverPasswordCommand);
            RememberPasswordCommand = new ViewModelCommand(ExecuteRememberPasswordCommand);
        }

        private void ExecuteLoginCommand(object obj)
        {
            //AutenticationUser
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(UserEmail) || Password == null || Password.Length < 6)
            {
                return false;
            }

            return true;
        }


        //Future Implementation
        private void ExecuteShowPasswordCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteShowPasswordCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteRememberPasswordCommand(object obj)
        {
            throw new NotImplementedException();
        }

        private void ExecuteRecoverPasswordCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
