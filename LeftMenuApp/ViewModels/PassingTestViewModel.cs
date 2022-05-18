using LeftMenuApp.Commands;
using LeftMenuApp.Data;
using LeftMenuApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class PassingTestViewModel : ViewModelBase
    {
        private Test selectedTest;
        private IList<QuestionTabViewModel> questions;

        private float acceptedAnswersPercentage;
        public float AcceptedAnswersPercentage
        {
            get => acceptedAnswersPercentage;
            set => Set(ref acceptedAnswersPercentage, value);
        }

        private int acceptedAnswersCount;
        public int AcceptedAnswersCount
        {
            get => acceptedAnswersCount;
            set => Set(ref acceptedAnswersCount, value);
        }

        private List<Test> allTest;
        public List<Test> AllTest
        {
            get => allTest;
            set => Set(ref allTest, value);
        }

        public Test SelectedTest
        {
            get => selectedTest;
            set => Set(ref selectedTest, value);
        }

        public IList<QuestionTabViewModel> Questions
        {
            get => questions;
            set => Set(ref questions, value);
        }

        public ICommand ViewLoadedCommand { get; set; }

        public ICommand StartTestCommand { get; set; }

        public ICommand EndTest { get; set; }


        public PassingTestViewModel()
        {
            ViewLoadedCommand = new RelayCommand(_ => GetAllTests()); //Get only test Title(id, title)
            StartTestCommand = new RelayCommand(_ => StartTest());
            EndTest = new RelayCommand(_ => AddStudentAnswers());
        }

        private void StartTest()
        {
            AcceptedAnswersCount = 0;
            AcceptedAnswersPercentage = 0;

            var questions = DataWorker.GetTestQuestionsWithAsnwers(SelectedTest.Id);
            Questions =
                questions.Select((i, n) =>
                    new QuestionTabViewModel
                    {
                        Id = i.Id,
                        Title = i.Title,
                        Number = n + 1,
                        Answers = i.Answers.Select(answer =>
                            new AnswerViewModel
                                {
                                    Id = answer.Id,
                                    AnswerText = answer.Title,
                                    AnswerNumber = 0                             // fix answer number
                                })
                        .ToList()
                    })
                .ToList();
        }

        private void AddStudentAnswers()
        {
            var correctQuestionsCount = 0;
            var correctQuestions = DataWorker.GetTestQuestionsWithAsnwers(SelectedTest.Id);

            foreach (var askedQuestion in Questions)
            {
                var answerAccepted = true;
                var correctAnswers = correctQuestions.Find(x => x.Id == askedQuestion.Id).Answers;

                // move this cycle to a separate method
                foreach(var studentsAnswer in askedQuestion.Answers)
                {
                    var correctAnswer = correctAnswers.First(x => x.Id == studentsAnswer.Id);

                    if (correctAnswer.IsAnswerCorrect != studentsAnswer.IsCorrect)
                    {
                        answerAccepted = false;
                        break;
                    }
                }
                if (answerAccepted)
                {
                    correctQuestionsCount++;
                }
            }

            AcceptedAnswersCount = correctQuestionsCount;
            AcceptedAnswersPercentage = 100f * AcceptedAnswersCount / Questions.Count;
            Questions = null;
        }

        private void GetAllTests()
        {
            AllTest = DataWorker.GetAllTest();
        }

    }
}
