using LeftMenuApp.Commands;
using LeftMenuApp.Data;
using LeftMenuApp.Model;
using System.Collections.Generic;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class ShowAllQuestionViewModel: ViewModelBase
    {
        private List<Question> allQuestions;
        public ICommand ViewLoadedCommand { get; set; }

        public ShowAllQuestionViewModel()
        {
            ViewLoadedCommand = new RelayCommand(_ => GetAllQuestion());
        }

        public List<Question> AllQuestions
        {
            get => allQuestions;
            set => Set(ref allQuestions, value);
        }

        private void GetAllQuestion()
        {
            AllQuestions = DataWorker.GetAllQuestions();
        }
    }
}
