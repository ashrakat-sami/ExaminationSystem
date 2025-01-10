using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class AnswerList<Answer> : List<Answer> 
    {
        public int Id { get; set; }
       
      

        public override string ToString()
        {
            string s = "";
            foreach (var item in this)
            {
                Console.WriteLine(item);
                s += $"{item.ToString()}  ";
            }
            return s;
        }






    }
}
