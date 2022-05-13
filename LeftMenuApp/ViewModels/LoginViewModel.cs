using LeftMenuApp.Commands;
using LeftMenuApp.Model;
using LeftMenuApp.Services;
using System;
using System.Windows;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string email;
        private string password;
        private Roles role;

        private readonly LoginService loginService;

        #region Commands

        public ICommand LoginCommand { get; set; }


        #endregion


        #region Properties

        public string Email
        {
            get => email;
            set => Set(ref email, value);
        }

        public string Password
        {
            get => password;
            set => Set(ref password, value);
        }

        public Roles Role
        {
            get => role;
            set => Set(ref role, value);
        }

        #endregion

        public LoginViewModel(LoginService loginService)
        {
            this.loginService = loginService;
            LoginCommand = new RelayCommand(LoginCommandImplementation);
        }
        private void LoginCommandImplementation(object parameter)
        {
            try
            {
                loginService.Login(this.Email, this.Password);
                Role = loginService.GetAuthorizedUser().Role;
            }
            catch (ArgumentNullException ex)
            {
                //TODO: Error handling
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException)
            {
                //TODO: Error handling
                MessageBox.Show("User or password not valid.");
            }

        }
    }
}