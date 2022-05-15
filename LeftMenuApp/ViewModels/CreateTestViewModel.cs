using LeftMenuApp.Commands;
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

        public BindingList<Question> Questions
        {
            get => questions;
            set => Set(ref questions, value);
        }

        public RelayCommand OpenCreateQuestionWindow { get; }

        public CreateTestViewModel()
        {
            OpenCreateQuestionWindow = new RelayCommand(_ => CreateQuestionWindow());
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
