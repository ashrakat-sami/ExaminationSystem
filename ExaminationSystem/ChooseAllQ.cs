using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class ChooseAllQ :Question
    {
        public ChooseAllQ(List<string> _choices) :base("ChooseAll",_choices)
        {
            
        }

        public List<Answer> Answers { get; set; }

        

    }
}
