using LeftMenuApp.Commands;
using LeftMenuApp.Model;
using LeftMenuApp.View;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class CreateTestViewModel: ViewModelBase
    {
        private BindingList<Test> tests;

        public BindingList<Test> Tests
        {
            get => tests;
            set => Set(ref tests, value);
        }

        public RelayCommand OpenCreateQuestionWindow { get; }

        public CreateTestViewModel()
        {
            OpenCreateQuestionWindow = new RelayCommand(_ => CreateQuestionWindow());
        }

        private void CreateQuestionWindow()
        {
            var createQuestionViewModel = new CreateQuestionViewModel();
            CreateNewQuestion newQuestionWindow = new CreateNewQuestion() { DataContext = createQuestionViewModel };
            newQuestionWindow.Owner = Application.Current.MainWindow;
            newQuestionWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (newQuestionWindow.ShowDialog() == true)
            {

            }
        }
    }
}
