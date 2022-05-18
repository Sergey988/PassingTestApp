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

        private ViewModelBase selectedViewModel;

        public ICommand LogoutCommand { get; set; }
        public ICommand ViewCommand { get; }

        public ViewModelBase SelectedViewModel
        {
            get => selectedViewModel;
            set => Set(ref selectedViewModel, value);
        }

        public StudentViewModel(LoginService loginService)
        {
            LogoutCommand = new RelayCommand(_ => loginService.LogoutAuthorizedUser());
            ViewCommand = new RelayCommand(SelectView);
        }

        private void SelectView(object parameter)
        {
            if (parameter.ToString() == "startTest")
            {
                SelectedViewModel = new PassingTestViewModel();
            }

        }
    }
}
