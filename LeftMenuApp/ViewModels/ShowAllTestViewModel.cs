using LeftMenuApp.Commands;
using LeftMenuApp.Data;
using LeftMenuApp.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class ShowAllTestViewModel: ViewModelBase
    {
        private string selectedTestName;

        private int selectedTestQuestionCount;

        private Test selectedTest;

        private List<Test> allTests;

        private List<Question> allQuestionsByTestId;

        public List<Test> AllTests
        {
            get => allTests;
            set => Set(ref allTests, value);
        }

        public List<Question> QuestionsForCurrentTest
        {
            get => allQuestionsByTestId;
            set => Set(ref allQuestionsByTestId, value);
        }

        public Test SelectedTest
        {
            get => selectedTest;
            set => Set(ref selectedTest, value);
        }

        public string SelectedTestName
        {
            get => selectedTestName;
            set => Set(ref selectedTestName, value);
        }

        public int SelectedTestQuestionCount
        {
            get => selectedTestQuestionCount;
            set => Set(ref selectedTestQuestionCount, value);
        }


        public ICommand ViewLoadedCommand { get; set; }
        public ICommand TestChangedCommand { get; set; }

        public ShowAllTestViewModel()
        {
            ViewLoadedCommand = new RelayCommand(_=> GetAllTest());
            TestChangedCommand = new RelayCommand(_ => GetTestQuestions());
        }

        private void GetAllTest()
        {
            AllTests = DataWorker.GetAllTest();
        }

        private void GetTestQuestions()
        {
            if(SelectedTest == null)
            {
                return;
            }

            QuestionsForCurrentTest = DataWorker.GetTestQuestions(SelectedTest.Id);
            SelectedTestName = SelectedTest.Title;
            SelectedTestQuestionCount = QuestionsForCurrentTest.Count();
        }
    }
}
