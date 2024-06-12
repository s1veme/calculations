using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;

namespace GeoApp.Presentation.Register.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly UserService _userService;
        private string _email;
        private string _password;
        private string _phoneNumber;
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

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
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

        public ICommand RegisterCommand { get; }
        public ICommand GoToLoginCommand { get; }

        public RegisterViewModel()
        {
            _userService = UserService.GetInstance();
            RegisterCommand = new RelayCommand(Register);
            GoToLoginCommand = new RelayCommand(GoToLogin);
        }

        private void Register()
        {
            try
            {
                _userService.RegisterUser(_email, _password, _phoneNumber);

                Main.View.Main mainWindow = new Main.View.Main();
                mainWindow.Show();
                (System.Windows.Application.Current.MainWindow).Close();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private void GoToLogin()
        {
            try
            {
                Login.View.Login mainWindow = new Login.View.Login();
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
