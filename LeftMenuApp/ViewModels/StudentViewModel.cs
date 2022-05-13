using LeftMenuApp.Commands;
using LeftMenuApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        public ICommand LogoutCommand { get; set; }

        public StudentViewModel(LoginService loginService)
        {
            LogoutCommand = new RelayCommand(_ => loginService.LogoutAuthorizedUser());
        }
    }
}
