using LeftMenuApp.Commands;
using LeftMenuApp.Services;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class TeacherViewModel : ViewModelBase
    {
        public ICommand LogoutCommand { get; }

        public ICommand ViewCommand { get; }

        private ViewModelBase selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get => selectedViewModel;
            set => Set(ref selectedViewModel, value);
        }

        public TeacherViewModel(LoginService loginService)
        {
            LogoutCommand = new RelayCommand(_ => loginService.LogoutAuthorizedUser());
            ViewCommand = new RelayCommand(SelectView);
        }

        private void SelectView(object parameter)
        {
            if (parameter.ToString() == "test")
            {
                SelectedViewModel = new CreateTestViewModel();
            }
            else if (parameter.ToString() == "question")
            {
                SelectedViewModel = new CreateQuestionViewModel();
            }
            else if (parameter.ToString() == "allTest")
            {
                SelectedViewModel = new ShowAllTestViewModel();
            }
            else if (parameter.ToString() == "allQuestion")
            {
                SelectedViewModel = new ShowAllQuestionViewModel();
            }
        }
    }
}
