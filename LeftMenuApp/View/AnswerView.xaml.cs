using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LeftMenuApp.View
{
    /// <summary>
    /// Interaction logic for AnswerView.xaml
    /// </summary>
    public partial class AnswerView : UserControl
    {
        public AnswerView()
        {
            InitializeComponent();
        }

        //public static DependencyProperty AnswerNumberProperty
        //    = DependencyProperty.Register(nameof(AnswerNumber), typeof(int), typeof(AnswerView));

        //public int AnswerNumber
        //{
        //    get => (int)GetValue(AnswerNumberProperty);
        //    set => SetValue(AnswerNumberProperty, value);
        //}

        //public static DependencyProperty AnswerTextProperty
        //    = DependencyProperty.Register(nameof(AnswerText), typeof(string), typeof(AnswerView));

        //public string AnswerText
        //{
        //    get => (string)GetValue(AnswerTextProperty);
        //    set => SetValue(AnswerTextProperty, value);
        //}

        //public static DependencyProperty IsCorrectProperty
        //    = DependencyProperty.Register(nameof(IsCorrect), typeof(bool), typeof(AnswerView));

        //public bool IsCorrect
        //{
        //    get => (bool)GetValue(IsCorrectProperty);
        //    set => SetValue(IsCorrectProperty, value);
        //}

        public static DependencyProperty IsReadOnlyProperty
            = DependencyProperty.Register(nameof(IsReadOnly), typeof(bool), typeof(AnswerView));

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

    }
}
