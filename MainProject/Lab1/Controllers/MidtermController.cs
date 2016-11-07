using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;


namespace CST465
{
    public class MidtermController : Controller
    {
        // GET: Midterm
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TakeTest()
        {
            return View(RetrieveQuestions() );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeTest(string dummyVar)
        {
            List<TestQuestion> questionList = RetrieveQuestions();

            foreach (TestQuestion question in questionList)
            {
                question.Answer = Request.QueryString[question.ID.ToString()];
            }

            if (ModelState.IsValid)
            {
                TempData["TestData"] = questionList;
                return RedirectToAction("DisplayResults");
            }
            else
            {
                return View(questionList);
            }
        }

        [HttpGet]
        public ActionResult DisplayResults()
        {
            List<TestQuestion> questionList = (List<TestQuestion>)TempData["TestData"];

            return View(questionList);
        }

        private List<TestQuestion> RetrieveQuestions()
        {
            List<TestQuestion> questionList = new List<TestQuestion>();
            string path = Server.MapPath(@"~/JSON/Midterm.json");
            string jsonString = System.IO.File.ReadAllText(path);
            JArray json = JArray.Parse(jsonString);

            int numQuestions = json.Count;

            for (int i = 0; i < numQuestions; ++i)
            {
                TestQuestion question = null;

                switch (json[i]["type"].ToString())
                {
                    case "TrueFalseQuestion":
                        question = new TrueFalseQuestion();
                        break;
                    case "ShortAnswerQuestion":
                        question = new ShortAnswerQuestion();
                        break;
                    case "LongAnswerQuestion":
                        question = new LongAnswerQuestion();
                        break;
                    case "MultipleChoiceQuestion":
                        question = new MultipleChoiceQuestion();
                        var choiceJList = json[i]["choices"].ToList();
                        List<string> choiceList = new List<string>();

                        foreach(var choiceString in choiceJList)
                        {
                            choiceList.Add(choiceString.ToString());
                        }
                        ((MultipleChoiceQuestion)question).Choices = choiceList;
                        break;
                }

                question.ID = (int)json[i]["id"];
                question.Question = json[i]["question"].ToString();
                questionList.Add(question);
            }

            return questionList;
        }
    }
}