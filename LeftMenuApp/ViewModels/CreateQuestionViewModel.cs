using LeftMenuApp.Commands;
using LeftMenuApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LeftMenuApp.ViewModels
{
    public class CreateQuestionViewModel : ViewModelBase
    {
        private string textChangedTextBox1;

        public string TextChangedTextBox1
        {
            get => textChangedTextBox1;
            set => Set(ref textChangedTextBox1, value);
        }

        public CreateQuestionViewModel()
        {
        }
    }
}
