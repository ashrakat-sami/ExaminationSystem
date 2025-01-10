using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExaminationSystem
{
    public enum ExamType
    {
        Final,Practice
    }
    internal  class Exam
    {
        public Exam(int _id, Dictionary<Question,Answer>_QA ,Subject _subject, int _time=60, int _Qnumber=5)
        {
            Id = _id;
            Subject = _subject;
            TimeDuration = _time;
            NumberOfQuestions = _Qnumber;
            QuestionAnswer = _QA;
        }
        public Exam(int _id,QuestionList<Question> _questions, Subject _subject, int _time = 60, int _Qnumber = 5)
        {
            Id = _id;
            Subject = _subject;
            TimeDuration = _time;
            NumberOfQuestions = _Qnumber;
            Questions = _questions;
        }

        public int Id { get; set; }
        public int TimeDuration { get; set; }
        public int NumberOfQuestions { get; set; }

       public Dictionary<Question, Answer> QuestionAnswer = new Dictionary<Question, Answer>();

        public QuestionList<Question> Questions { get; set; }

        public Subject Subject { get; set; }

        public virtual  void ShowExam()
        {
            
        }

        public static AnswerList<Answer> ShowAnswers(Question question, int ansId)
        {
            
           
            AnswerList<Answer> ansList = new AnswerList<Answer>();
            Answer a=new Answer(ansId);

            if (question.Type == "ChooseOne")
            {

                ChooseOneQ chooseOne = (ChooseOneQ)question;
                a .Body = chooseOne.Answer.ToString() ;
                ansList.Add(a);

            }
            else if (question.Type == "TrueFalse")
            {

                TrueFalseQ trueFalse = (TrueFalseQ)question;
                a.Body = trueFalse.Answer.ToString() ;
                ansList.Add(a);
            }
            else   //Choose All
            {
               
                ChooseAllQ chooseAll = (ChooseAllQ)question;
                foreach(var ans in chooseAll.Answers)   // عشان ف الطباعه ال id يكون مظبوط
                {
                    ans.Id= ansId;
                }
                ansList.AddRange(chooseAll.Answers);

            }
            return ansList;

        }


        public static bool Check(string ans)
        {
            bool check = false;


            while (bool.TryParse(ans, out check) == false)
            {
                ans = Console.ReadLine();
            }

            return check;

        }

        protected static void ShowDegree(int m, int t)
        {
            Console.WriteLine("Show Degree?(y/n)");
            string choice = Console.ReadLine();
            if (choice == "y")
            {
                Console.WriteLine($"you have got {m} out of {t}\n");
            }
            else if (choice != "n")
            {
                ShowDegree(m, t);
            }
        }

        private ExamModeEnum mode;
        public ExamModeEnum Mode
        {
            get => mode;
            set
            {
                mode = value;
                if (mode == ExamModeEnum.Starting)
                {
                    NotifyStudents();
                }
            }
        }
        public  Action<string> OnExamStarted; //Event for sending notification about exam starting
        private void NotifyStudents()
        {
            if (OnExamStarted != null)
            {
                foreach (var student in Subject.Students)
                {
                    OnExamStarted?.Invoke($"{student.Name}: The exam '{Id}' has started!");  // this message will be sent as a param for ExamNotification function


                }
            }
        }



    }
}
