using LeftMenuApp.Commands;
using LeftMenuApp.Data;
using LeftMenuApp.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class CreateQuestionViewModel : ViewModelBase
    {
        private Question question;

        private string questionTitle;

        private ObservableCollection<AnswerViewModel> answers;

        public ObservableCollection<AnswerViewModel> Answers
        {
            get => answers;
            set => Set(ref answers, value);
        }

        public Question Question
        {
            get => question;
            set => Set(ref question, value);
        }

        public string QuestionTitle
        {
            get => questionTitle;
            set => Set(ref questionTitle, value);
        }

        public ICommand CreateQuestion { get; set; }

        public ICommand AddAnswerCommand { get; set; }

        public CreateQuestionViewModel()
        {
            Answers = new ObservableCollection<AnswerViewModel>();

            CreateQuestion = new RelayCommand(CreateNewQuestion);
            AddAnswerCommand = new RelayCommand(
                _ => Answers.Add(new AnswerViewModel() { AnswerNumber = Answers.Count + 1 }),
                _ => Answers.Count < 3);
        }

        public void CreateNewQuestion(object parameter)
        {
            if (!IsQuestionValid())
            {
                return;
            }

            Question = new Question
            {
                Title = QuestionTitle,
                Answers = Answers.Select(x => x.Answer).ToList()
            };

            (parameter as Window).DialogResult = true;
        }

        private bool IsQuestionValid()
            => !string.IsNullOrEmpty(QuestionTitle)
               && Answers.All(x => x.ModelValid)
               && Answers.Any(x => x.IsCorrect);
    }
}
