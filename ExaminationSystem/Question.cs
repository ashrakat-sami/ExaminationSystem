using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Question:IComparable<Question> , ICloneable
    {
        public int Id { get; set; }

        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }

        // public AnswerList<Answer> Answers { get; set; }
        public string Type { get; set; }
        public List<string> Choices { get; set; }
        public Question(string _type,List<string> _choices )
        {
            Type = _type;
            Choices = _choices;
        }
        public Question()
        {
            
        }
        public object Clone()
        {
            return this.MemberwiseClone();  //shallow copy 
        }

        public int CompareTo(Question? other)
        {
            return Mark.CompareTo(other.Mark);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            Question Q = (Question)obj;
            return this.Mark==Q.Mark && this.Body == Q.Body;
        }

        public override int GetHashCode()  // should be same as equal
        {
            return HashCode.Combine(Body, Mark);
        }

        public override string ToString()
        {
            return $"{Id}:{Header} {Body} {Type} ({Mark})";
        }

       


    }
}
