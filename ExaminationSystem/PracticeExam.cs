using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class PracticeExam : Exam
    {
        //Constructor chaining
        public PracticeExam(int _id, Dictionary<Question, Answer> _QA, Subject _subject, int _time = 60, int _Qnumber = 5):base(_id,_QA,_subject,_time,_Qnumber)
        {
            
        }
        public PracticeExam(int _id, QuestionList<Question> _questions, Subject _subject, int _time = 60, int _Qnumber = 5) : base(_id, _questions, _subject, _time, _Qnumber)
        {
        }
        //public override void ShowExam()
        //{
        //    int marks = 0;
        //    int total = 0;
        //    foreach (var pair in QuestionAnswer)
        //    {
        //        total += pair.Key.Mark;
        //        Console.WriteLine($"{pair.Key.Body}");    // To show the question

        //        if(pair.Value.Body == Console.ReadLine())
        //        {
        //            Console.ForegroundColor = ConsoleColor.Green;
        //            Console.WriteLine("Correct!");
        //            Console.ForegroundColor = ConsoleColor.White;
        //            marks+=pair.Key.Mark;
        //        }
        //        else
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine($"the correct answer is: {pair.Value.Body}");
        //            Console.ForegroundColor = ConsoleColor.White;
        //        }

        //    }
        //    Console.WriteLine($"you have got {marks} out of {total}");
        //}

        public override void ShowExam()
        {
            int marks = 0;
            int total = 0;
            string userAnswer = "";
            int ansId = 0;

            AnswerList<Answer> examAnswers = new AnswerList<Answer>();
            foreach (var q in Questions)
            {
                total += q.Mark;
                ansId++;


                Console.WriteLine(q);    // To show the question
                foreach (var choice in q.Choices)
                {
                    Console.WriteLine(choice);
                }
                userAnswer = Console.ReadLine();


                if (q.Type == "ChooseOne")
                {

                    char firstChar = userAnswer[0];
                    ChooseOneQ chooseOne = (ChooseOneQ)q;
                   
                    if (firstChar == chooseOne.Answer)
                    {
                        CorrectAnswer(ref marks,chooseOne);
                       
                    }
                    else
                    {
                        WrongAnswer(chooseOne.Answer);
                    }
                    
                }
                else if (q.Type == "TrueFalse")
                {

                    TrueFalseQ trueFalse = (TrueFalseQ)q;

                    bool uAns = Check(userAnswer);

                    if (uAns == trueFalse.Answer) 
                    {
                        CorrectAnswer(ref marks, trueFalse);
                    }
                    else
                    {
                        WrongAnswer(trueFalse.Answer);
                    }

                }
                else   //Choose All
                {
                    string answers = "";
                    ChooseAllQ chooseAll = (ChooseAllQ)q;
                    foreach (var ans in chooseAll.Answers)
                    {
                        answers += ans.Body;
                    }
                    if (answers == userAnswer)
                    {
                        CorrectAnswer(ref marks, chooseAll);
                    }
                    else
                    {
                        WrongAnswer(answers);
                    }

                }

                examAnswers.AddRange(ShowAnswers(q, ansId));

            }

            ShowDegree(marks, total);

            Console.WriteLine("Exam Answers:");
            foreach(var answer in examAnswers)
            {
                Console.WriteLine(answer);
            }


        }


        public static void CorrectAnswer(ref int marks, Question chooseOne)
        {
            marks += chooseOne.Mark;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Correct!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WrongAnswer(object? a)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"the correct answer is: {a}");
            Console.ForegroundColor = ConsoleColor.White;
        }



    }
}
