using LeftMenuApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LeftMenuApp.Infrastructure
{
    public class MainViewTemplateselector : DataTemplateSelector
    {
        public DataTemplate LoginViewTemplate { get; set; }

        public DataTemplate TeacherViewTemplate { get; set; }

        public DataTemplate StudentViewTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if(item is TeacherViewModel)
            {
                return TeacherViewTemplate;
            }

            if (item is StudentViewModel)
            {
                return StudentViewTemplate;
            }

            return LoginViewTemplate;
        }
    }
}
