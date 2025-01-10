using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    internal class ChooseOneQ : Question
    {
        public ChooseOneQ(List<string> _choices):base("ChooseOne",_choices)
        {
            
        }

        public char Answer { get; set; }

       

    }
}
