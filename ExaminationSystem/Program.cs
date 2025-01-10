
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;

namespace ExaminationSystem
{
    internal class Program
    {
        #region Old Fun1
        //public static void UserChoice(int id,Dictionary<Question, Answer> ExamQuestion,Subject subject,int time ,int Qnum)

        //{//وظيفتها انها تستقبل اختيار اليوزر لنوع الامتحان وبناء عليه تعرض الامتحان
        //    int choice;
        //    Exam exam;      //عملتها كده عشان اخلى ال فور ف الحالتين نفس الطريقه ف اقدر احطه مره واحده من غير ما اكرر الكود
        //    string type;     //for printing only
        //    bool valid;
        //    do
        //    {
        //        Console.WriteLine("Choose Type of Exam:\n1-Practice Exam  2-Final Exam");
        //        valid = int.TryParse(Console.ReadLine(), out choice);

        //    }

        //    while (valid == false);



        //    if (choice == 1 || choice == 2)
        //    {

        //        if (choice == 1)
        //        {
        //            type = "Practice";
        //            exam = new PracticeExam(id, ExamQuestion, subject, time, Qnum); 


        //        }
        //        else 
        //        {
        //            type = "Final";
        //            exam = new FinalExam(1, ExamQuestion, subject, time, Qnum);

        //        }

        //        StartExam(exam, subject);   //بحاول اقلل الكود من الميثود دي واحقق مبدا Single Responsability Principle

        //        Console.WriteLine($"\n{type} Exam: (Duration:{time}min - Number of Question:{Qnum})\n");

        //        exam.ShowExam();

        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid choice");
        //        UserChoice(1, ExamQuestion, subject, time, Qnum);
        //    }
        //}
        #endregion

        #region old fun2 
        //public static void ShowingTheExam(ExamType Etype, Exam exam)
        //{
        //    string type;     //for printing only
        //    if (Etype == ExamType.Final)
        //    {
        //        type = "Final";
        //        exam = new FinalExam(exam.Id, exam.Questions, exam.Subject, exam.TimeDuration, exam.NumberOfQuestions);
        //    }
        //    else //if (Etype == ExamType.Practice)
        //    {
        //        type = "Practice";
        //        exam = new PracticeExam(exam.Id, exam.QuestionAnswer, exam.Subject, exam.TimeDuration, exam.NumberOfQuestions);
        //    }
        //    StartExam(exam);   //بحاول اقلل الكود من الميثود دي واحقق مبدا Single Responsability Principle

        //    Console.WriteLine($"\n{type} Exam: (Duration:{exam.TimeDuration}min - Number of Question:{exam.NumberOfQuestions})\n");

        //    exam.ShowExam();
        //}
        #endregion      

        public static void ShowingTheExam( Exam exam)
        {
            int choice;
            string type;     //for printing only
            bool valid;
            do
            {
               valid= Student.Login();
               

            }

            while (valid == false);
            do
            {
                Console.WriteLine("Choose Type of Exam:\n1-Practice Exam  2-Final Exam");
                valid = int.TryParse(Console.ReadLine(), out choice);

            }

            while (valid == false);
            if (choice == 1 || choice == 2)
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                if (choice == 1)
                {
                    type = "Practice";
                    exam = new PracticeExam(exam.Id, exam.Questions, exam.Subject, exam.TimeDuration, exam.NumberOfQuestions);
                }

                else
                {
                    type = "Final";
                   exam = new FinalExam(exam.Id, exam.Questions, exam.Subject, exam.TimeDuration, exam.NumberOfQuestions);
                }

               
                    StartExam(exam);   //بحاول اقلل الكود من الميثود دي واحقق مبدا Single Responsability Principle

                Console.WriteLine($"\n{type} Exam:  Number of Question:{exam.NumberOfQuestions})\n");
               
                    exam.ShowExam();

                

                timer.Stop();
                Console.WriteLine("Exam finished.");
                TimeSpan elapsed = timer.Elapsed;
               
                Console.WriteLine($"Time taken: {elapsed.Hours:D2}:{elapsed.Minutes:D2}:{elapsed.Seconds:D2}");
            }
            else
            {
                Console.WriteLine("Invalid choice");
                ShowingTheExam( exam);
            }
        }

        public static void StartExam(Exam exam)
        {
            foreach (var student in exam.Subject.Students)
            {
                exam.OnExamStarted = student.ExamNotification;

            }
            exam.Mode = ExamModeEnum.Starting;
        }


        static void Main(string[] args)
        {

            Student student1 = new Student() { Id = 1, Name = "Ali" };
            Student student2 = new Student() { Id = 2, Name = "Ahmed" };
            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student2);

            Subject subject = new Subject() { Id = 1, Name = "cSharp" ,Students=students };

           

            #region test
            // UserChoice(1, ExamQuestion, subject, 20,ExamQuestion.Count);


            //List<string> all1Choise = new List<string>() { "a", "b", "c" };
            //List<Answer> all1Ans = new List<Answer>() { new Answer(1, "a"), new Answer(2, "b") };

            //ChooseAllQ all1 = new ChooseAllQ(all1Choise) { Answers = all1Ans };
            //Dictionary<Question, Answer> allDic = new Dictionary<Question, Answer>();

            //for(int i=0; i<all1Ans.Count; i++)
            //{

            //}
            #endregion

            //EXAM***********************************

            TrueFalseQ tf1 = new TrueFalseQ() {Id=1, Body= "C# supports multiple inheritance for classes directly." , Answer = false, Mark=5 };
            TrueFalseQ tf2= new TrueFalseQ() {Id=2, Body= "C# uses garbage collection to manage memory automatically.", Answer = true, Mark=5 };
            ChooseOneQ co1 = new ChooseOneQ(new List<string> { "a) string", "b) int", "c) object" }) {Id=3, Body = " Which of the following is a value type in C#?", Answer ='b', Mark=10 };

            List<Answer> answerList = new List<Answer>() { new Answer(1,"b"), new Answer(2, "c") };
            ChooseAllQ ca1 = new ChooseAllQ(new List<string> { "a) Html", "b) Python", "c) JavaScript" }) { Id = 4 , Body= "Which of the following are programming languages?" , Answers= answerList , Mark=20};

            QuestionList<Question> ql1 = new QuestionList<Question>("C:\\Users\\Ashrakat\\Desktop\\Exam1.txt") ;
            ql1.Add(tf1);
            ql1.Add(tf2);
            ql1.Add(co1);
            ql1.Add(ca1);

            #region   Sending type of exam from main 
            //PracticeExam practice1 = new PracticeExam(1, ExamQuestion, subject, 20, ExamQuestion.Count);
            //ShowingTheExam(ExamType.Practice, practice1);

            //Exam final1 = new FinalExam(1, ql1, subject, 20, ExamQuestion.Count);
            //ShowingTheExam(ExamType.Final,final1);



            //UserChoice(1, allDic, subject, 20,  allDic.Count);
            #endregion

            Exam exam1 = new Exam(1, ql1, subject, 20, ql1.Count);
            ShowingTheExam(exam1);



           



            Console.ReadKey();
        }
    }
}
