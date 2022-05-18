using LeftMenuApp.Model;
using System.Collections.Generic;

namespace LeftMenuApp.ViewModels
{
    public class QuestionTabViewModel : ViewModelBase
    {
        private int number;
        private IList<AnswerViewModel> answers;
        private string title;
        public int Id { get; set; }

        public int Number
        {
            get => number;
            set => Set(ref number, value);
        }

        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }

        public IList<AnswerViewModel> Answers
        {
            get => answers;
            set => Set(ref answers, value);
        }
    }
}
