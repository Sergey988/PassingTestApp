using System;
using System.Collections.Generic;
using System.Linq;
using LeftMenuApp.Model;
using Microsoft.EntityFrameworkCore;

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

        public static List<Question> GetTestQuestions(int testId)
        {
            // save 1 call to database
            if (testId <= 0)
            {
                throw new ArgumentException(nameof(testId));
            }

            using (var db = new AppContextDb())
            {
                return db.Questions.Where(q => q.Test.Id == testId).ToList();
            }
        }

        public static List<Question> GetTestQuestionsWithAsnwers(int testId)
        {
            // save 1 call to database
            if (testId <= 0)
            {
                throw new ArgumentException(nameof(testId));
            }

            using (var db = new AppContextDb())
            {
                return db.Questions
                         .Where(q => q.Test.Id == testId)
                         .Include(x => x.Answers)
                         .ToList();
            }
        }

        public static List<Test> GetAllTest()
        {
            using (AppContextDb db = new AppContextDb())
            {
                return db.Tests.ToList();
            }
        }

        public static Answer CreateAnswer(string answerName, bool IsAnswerCorrect, Question question)
        {
            using (AppContextDb db = new AppContextDb())
            {
                var isExist = db.Answers.Any(q => q.Title.Equals(answerName, System.StringComparison.OrdinalIgnoreCase));

                if (isExist)
                {
                    throw new ArgumentException(nameof(answerName));
                }

                var newAnswer = new Answer
                {
                    Title = answerName,
                    IsAnswerCorrect = IsAnswerCorrect,
                    Question = question
                };

                db.Answers.Add(newAnswer);
                db.SaveChanges();

                return newAnswer;
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

        public static string CreateTest(string testTitle, IList<Question> question)
        {
            using (AppContextDb db = new AppContextDb())
            {
                string result = "Exeption";

                bool checkIsExist = db.Tests.Any(q => q.Title == testTitle);

                if (checkIsExist)
                    return result;

                Test newTest = new()
                {
                    Title = testTitle,
                    Questions = question.ToList()
                };

                db.Tests.Add(newTest);
                db.SaveChanges();
                return "Ok";
            }
        }
    }
}
