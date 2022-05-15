using LeftMenuApp.Model;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public sealed class AnswerViewModel : ViewModelBase
    {
        private int number;
        private string text;
        private bool isCorrect;

        public Answer Answer =>
            new Answer { Title = text, IsAnswerCorrect = IsCorrect };

        public bool ModelValid => !string.IsNullOrEmpty(AnswerText);

        public int AnswerNumber
        {
            get => number;
            set => Set(ref number, value);
        }

        public string AnswerText
        {
            get => text;
            set => Set(ref text, value);
        }

        public bool IsCorrect
        {
            get => isCorrect;
            set => Set(ref isCorrect, value);
        }
    }
}
