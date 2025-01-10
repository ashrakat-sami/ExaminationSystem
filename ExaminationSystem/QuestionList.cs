using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class QuestionList<Question> : List<Question>
    {
        public string FilePath { get; set; }
        public QuestionList(string path)
        {
            FilePath = path;
        }
       



        public void Add(Question question)
        {
            
            var existingQuestions = File.Exists(FilePath)? File.ReadAllLines(FilePath): new string[0];   //to check if the file exists

            if (!existingQuestions.Contains(question.ToString()))
            {
                using (TextWriter textWriter = File.AppendText(FilePath))
                {
                    textWriter.WriteLine(question.ToString());

                }
                
            }
            else
            {
               
                Console.WriteLine("Question already exists in the file\n");
              
            }
            base.Add(question);
        }


       




    }
}
