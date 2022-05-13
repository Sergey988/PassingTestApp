namespace LeftMenuApp.Model
{
    public class Answer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsAnswerCorrect { get; set; }
        public Question Question { get; set; }
    }
}
