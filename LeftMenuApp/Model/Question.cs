using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftMenuApp.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Test Test { get; set; }
        public ICollection<Answer> Answers { get; set; }

    }
}
