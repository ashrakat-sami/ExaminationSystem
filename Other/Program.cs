using ExaminationSystem;

namespace Other
{
    internal class Program
    {
        static void Main(string[] args)
        {

          

            Question Eq1 = new Question() { Id = 1, Body = "What is a Class in C#?", Mark = 20 };
            Answer Ea1 = new Answer(1) { Body = "A blueprint for creating objects." };

            Question Eq2 = new Question() { Id = 2, Body = "What is the difference between '==' and '.Equals()' in C#?", Mark = 15 };
            Answer Ea2 = new Answer(2) { Body = "'==' checks reference equality; '.Equals()' checks value equality." };


            Question Eq3 = new Question() { Id = 3, Body = "What is the size of an int in C#?", Mark = 10 };
            Answer Ea3 = new Answer(3) { Body = "4" };



            Dictionary<Question, Answer> ExamQuestion = new Dictionary<Question, Answer>();
            ExamQuestion.Add(Eq1, Ea1);
            ExamQuestion.Add(Eq2, Ea2);
            ExamQuestion.Add(Eq3, Ea3);


            //Add to file
            QuestionList<Question> questions1 = new QuestionList<Question>("C:\\Users\\Ashrakat\\Desktop\\code1.txt");
            questions1.Add(Eq1);
            questions1.Add(Eq2);

            QuestionList<Question> questions2 = new QuestionList<Question>("C:\\Users\\Ashrakat\\Desktop\\code2.txt");
            questions2.Add(Eq3);




            //To try IComparable (CompareTo) implementation
            List<Question> Comparingquestions = new List<Question>();
            Comparingquestions.AddRange(new[] { Eq1, Eq2, Eq3 });
            Comparingquestions.Sort();   // based on marks   1:20  2:15  3:10
            Console.WriteLine("Sorted questions based on their mark:");
            foreach (Question question in Comparingquestions)
            {
                Console.WriteLine(question);     // print the override toString
            }



            Console.WriteLine("******************************************************");
            Question q1 = new Question() { Id = 10, Body = "What is C#?", Mark = 5 };
            Question q2 = new Question() { Id = 12, Body = "What is C#?", Mark = 5 };
            Question q3 = new Question() { Id = 14, Body = "Explain OOP concepts.", Mark = 10 };

            Console.WriteLine(q1.Equals(q2));  //Equls override 
            Console.WriteLine(q1.Equals(q3));  //check equality based on body & mark


            Console.WriteLine("******************************************************");

            //q1,q2 have the same hashCode because they are equal based on body & mark
            Console.WriteLine(q1.GetHashCode());
            Console.WriteLine(q2.GetHashCode());
            Console.WriteLine(q3.GetHashCode());

            Console.WriteLine("******************************************************");

            Question original = new Question() { Id = 20, Body = "What is C#?", Mark = 25 };        //IClonable Implementation
            Question cloned = (Question)original.Clone();

            Console.WriteLine("Before modification:");
            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Cloned: {cloned}");

            // Edit Clone
            cloned.Body = "Explain OOP concepts";
            cloned.Id = 21;
            Console.WriteLine("\nAfter modification:");
            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Cloned: {cloned}");


            Console.ReadKey();
        }
    }
}
