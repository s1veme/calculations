using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;

namespace GeoApp.Presentation.Login.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserService _userService;
        private string _email;
        private string _password;
        private string _errorMessage;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _userService = UserService.GetInstance();
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            try
            {
                _userService.LoginUser(Email, Password);

                Main.View.Main mainWindow = new Main.View.Main();
                mainWindow.Show();
                (System.Windows.Application.Current.MainWindow).Close();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
