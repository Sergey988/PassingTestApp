using LeftMenuApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace LeftMenuApp.Data
{
    public static class DataWorker
    {
        //need to refactor all methods in this class
        public static List<Question> GetAllQuestions()
        {
            using (AppContextDb db = new AppContextDb())
            {
                return db.Questions.ToList();
            }
        }

        public static List<Question> GetAllQuestionsByTestId(int testId)
        {
            // save 1 call to database
            if (testId <= 0)
                return new();

            using (AppContextDb db = new AppContextDb())
            {
                return db.Questions.Where(q => q.Test.Id == testId).ToList();
            }
        }

        public static List<Test> GetAllTest()
        {
            using (AppContextDb db = new AppContextDb())
            {
                return db.Tests.ToList();
            }
        }

        public static string CreateAnswer(string answerName, bool IsAnswerCorrect, Question question)
        {
            string result = "Exeption";

            using (AppContextDb db = new AppContextDb())
            {
                bool checkIsExist = db.Answers.Any(q => q.Title == answerName);

                if (checkIsExist)
                    return result;

                Answer newAnswer = new Answer
                {
                    Title = answerName,
                    IsAnswerCorrect = IsAnswerCorrect,
                    Question = question
                };

                db.Answers.Add(newAnswer);
                db.SaveChanges();
                return "OK";
            }
        }

        public static string CreateQuestion(string questionName, List<Answer> answers)
        {
            string result = "Exeption";

            using (AppContextDb db = new AppContextDb())
            {
                bool checkIsExist = db.Questions.Any(q => q.Title == questionName);

                if (checkIsExist)
                    return result;

                Question newQuestion = new Question
                {
                    Title = questionName,
                    Answers = answers
                };

                db.Questions.Add(newQuestion);
                db.SaveChanges();
                return "OK";
            }
        }

        public static string CreateTest(string testName, List<Question> questions)
        {
            string result = "Exeption";

            using (AppContextDb db = new AppContextDb())
            {
                bool checkIsExist = db.Tests.Any(q => q.Title == testName);

                if (checkIsExist)
                    return result;

                Test newTest = new Test
                {
                    Title = testName
                };

                db.Tests.Add(newTest);
                db.SaveChanges();
                return "OK";
            }
        }
    }
}
