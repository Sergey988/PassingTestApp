using LeftMenuApp.Commands;
using LeftMenuApp.Data;
using LeftMenuApp.Model;
using LeftMenuApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class CreateTestViewModel: ViewModelBase
    {
        private BindingList<Question> questions;

        private string testTitle;

        public string TestTitle
        {
            get => testTitle;
            set => Set(ref testTitle, value);
        }

        public BindingList<Question> Questions
        {
            get => questions;
            set => Set(ref questions, value);
        }

        public RelayCommand OpenCreateQuestionWindow { get; }
        public ICommand CreateTestCommand { get; set; }

        public CreateTestViewModel()
        {
            OpenCreateQuestionWindow = new RelayCommand(_ => CreateQuestionWindow());
            Questions = new();
            CreateTestCommand = new RelayCommand(_=> CreateTest());
        }

        private void CreateTest()
        {
            if (string.IsNullOrEmpty(TestTitle))
                return;

            DataWorker.CreateTest(TestTitle, Questions);
            TestTitle = null;
            Questions = new();
        }

        private void CreateQuestionWindow()
        {
            var createQuestionViewModel = new CreateQuestionViewModel();
            var newQuestionWindow = new CreateNewQuestion() { DataContext = createQuestionViewModel };

            newQuestionWindow.Owner = Application.Current.MainWindow;
            newQuestionWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            if (newQuestionWindow.ShowDialog() == true)
            {
                Questions.Add(createQuestionViewModel.Question);

            }

        }
    }
}
