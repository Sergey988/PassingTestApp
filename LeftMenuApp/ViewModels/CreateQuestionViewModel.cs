using LeftMenuApp.Commands;
using LeftMenuApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class CreateQuestionViewModel : ViewModelBase
    {
        private Question question;

        private string answerFirst;

        private string answerSecond;

        private string answerThird;

        private string questionTitle;

        private string isCorrectAnswerFirst = "False";

        private string isCorrectAnswerSecond = "False";

        private string isCorrectAnswerThird = "False";

        //private string isCancel = "false";

        //public string IsCancel
        //{
        //    get => isCancel;
        //    set => Set(ref isCancel, value);
        //}


        public Question Question
        {
            get => question;
            set => Set(ref question, value);
        }

        public string IsCorrectAnswerFirst
        {
            get => isCorrectAnswerFirst;
            set => Set(ref isCorrectAnswerFirst, value);
        }

        public string IsCorrectAnswerSecond
        {
            get => isCorrectAnswerSecond;
            set => Set(ref isCorrectAnswerSecond, value);
        }
        public string IsCorrectAnswerThird
        {
            get => isCorrectAnswerThird;
            set => Set(ref isCorrectAnswerThird, value);
        }

        public string QuestionTitle
        {
            get => questionTitle;
            set => Set(ref questionTitle, value);
        }

        public string AnswerFirst
        {
            get => answerFirst;
            set => Set(ref answerFirst, value);
        }

        public string AnswerSecond
        {
            get => answerSecond;
            set => Set(ref answerSecond, value);
        }

        public string AnswerThird
        {
            get => answerThird;
            set => Set(ref answerThird, value);
        }

        public ICommand CreateQuestion { get; set; }

        public CreateQuestionViewModel()
        {
            CreateQuestion = new RelayCommand(CreateNewQuestion);
        }

        public void CreateNewQuestion(object parameter)
        {
            var listAnswer = new List<Answer>() {
                new Answer
                {
                    Title = AnswerFirst,
                    IsAnswerCorrect = Convert.ToBoolean(IsCorrectAnswerFirst)
                },
                new Answer
                {
                    Title = AnswerSecond,
                    IsAnswerCorrect = Convert.ToBoolean(IsCorrectAnswerSecond)
                },
                new Answer
                {
                    Title = AnswerThird,
                    IsAnswerCorrect = Convert.ToBoolean(IsCorrectAnswerThird)
                }
            };

            Question = new Question
            {
                Title = QuestionTitle,
                Answers = listAnswer
            };
            (parameter as Window).DialogResult = true;
            //IsCancel = "True";
        }
    }
}
