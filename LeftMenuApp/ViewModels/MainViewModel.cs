using LeftMenuApp.Commands;
using LeftMenuApp.Data;
using LeftMenuApp.Model;
using LeftMenuApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase mainViewContent;

        private readonly LoginService loginService;

        public MainViewModel(LoginService loginService)
        {
            // TODO: unsubscribe
            mainViewContent = new LoginViewModel(loginService);
            this.loginService = loginService;
            loginService.OnLoginChanged += LoginService_OnLoginChanged;
        }

        private void LoginService_OnLoginChanged(object sender, EventArgs e)
        {
            var authorizedUser = loginService.GetAuthorizedUser();

            switch (authorizedUser?.Role)
            {
                default:
                case Roles.Unknown:
                    MainViewContent = new LoginViewModel(loginService);
                    break;

                case Roles.Student:
                    MainViewContent = new StudentViewModel(loginService);
                    break;

                case Roles.Teacher:
                    MainViewContent = new TeacherViewModel(loginService);
                    break;
            }
        }

        public ViewModelBase MainViewContent
        {
            get => mainViewContent;
            set => Set(ref mainViewContent, value);
        }
    }
}
