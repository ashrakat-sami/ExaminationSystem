using ExaminationSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExaminationSystem
{
    internal class FinalExam : Exam
    {
        //Constructor chaining
        public FinalExam(int _id, Dictionary<Question, Answer> _QA, Subject _subject, int _time = 60, int _Qnumber = 5) : base(_id, _QA, _subject, _time, _Qnumber)
        {
        }
        public FinalExam(int _id, QuestionList<Question> _questions, Subject _subject, int _time = 60, int _Qnumber = 5) : base(_id, _questions, _subject, _time, _Qnumber)
        {
        }



        #region Old Implementation for ShowExam
        //public override void ShowExam()
        //{
        //    int marks = 0;
        //    int total = 0;
        //    foreach (var pair in QuestionAnswer)
        //    {
        //        total += pair.Key.Mark;
        //        Console.WriteLine($"{pair.Key.Body}");    // To show the question

        //        if (pair.Value.Body == Console.ReadLine())
        //        {

        //            marks += pair.Key.Mark;
        //        }

        //    }
        //    Console.WriteLine($"you have got {marks} out of {total}");
        //}
        //public override void ShowExam()
        //{
        //    int marks = 0;
        //    int total = 0;

        //    foreach (var pair in QuestionAnswer)
        //    {
        //        total += pair.Key.Mark;
        //        Console.WriteLine($"{pair.Key.Body}");    // To show the question

        //        foreach (var choice in pair.Key.Choices)
        //        {
        //            Console.WriteLine(choice);
        //        }

        //        if (pair.Key.Type == "ChooseAll")
        //        {
        //            marks += ChooseAll(pair);
        //        }
        //        else if (pair.Value.Body == Console.ReadLine())
        //        {

        //            marks += pair.Key.Mark;
        //        }



        //    }
        //    Console.WriteLine($"you have got {marks} out of {total}");
        //}

        //public static int ChooseAll(KeyValuePair<Question, Answer> _QA )
        //{
        //  ChooseAllQ allQ=  _QA.Key as ChooseAllQ;
        //    allQ.Answers.Sort();
        //    string correct = "";
        //    foreach (var ans in allQ.Answers)
        //    {
        //        correct += $"{ans.Body} ";
        //    }
        //    int count = 0;
        //    string userAns = "";
        //    while (count< allQ.Answers.Count)
        //    {
        //        if (int.Parse(Console.ReadLine()) != 13)
        //            userAns += $"{Console.ReadLine()} ";
        //        else
        //            break;
        //        count++;
        //    }
        //    if (correct == userAns)
        //    {
        //        return _QA.Key.Mark;
        //    }
        //    else
        //        return 0;


        //}
        #endregion



        public override void ShowExam()
        {
           
            int marks = 0;
            int total = 0;
            string userAnswer = "";
           

            foreach (var q in Questions)
            {
                total += q.Mark;
               

                Console.WriteLine(q);    // To show the question
                foreach (var choice in q.Choices)
                {
                    Console.WriteLine(choice);
                }
                userAnswer=Console.ReadLine();
                

                if (q.Type== "ChooseOne")
                {
                    char firstChar = userAnswer[0];
                    ChooseOneQ chooseOne = (ChooseOneQ)q;
                    if(firstChar == chooseOne.Answer)
                    {
                        marks += chooseOne.Mark;
                    }
                }
                else if(q.Type== "TrueFalse")
                {

                    TrueFalseQ trueFalse = (TrueFalseQ)q;

                    bool uAns = Check(userAnswer);

                    if (uAns == trueFalse.Answer) 
                    {
                        marks += trueFalse.Mark;
                    }

                }
                else
                {
                    string answers = "";
                    ChooseAllQ chooseAll = (ChooseAllQ)q;
                    foreach(var ans in chooseAll.Answers)
                    {
                        answers += ans.Body;
                    }
                    if(answers == userAnswer)
                    {
                        marks += chooseAll.Mark;
                    }
                    else
                    {

                    }
                   
                }
                
            }

            ShowDegree(marks, total);


        }



    }
}

