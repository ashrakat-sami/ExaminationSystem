using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class TrueFalseQ : Question
    {
        public TrueFalseQ():base("TrueFalse",new List<string>() { "true","false"})
        {
            
        }

        public bool Answer { get; set; } 
       
    }
}
