using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem
{
    public class Answer: IComparable<Answer>
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public Answer(int _id):this(_id,"Empty")   //Constructor Chaining
        {
            Id= _id;
        }
        public Answer(int _id,string _body)
        {
            Id = _id;
            Body= _body;
        }


       




        public int CompareTo(Answer? other)
        {
            return Body.CompareTo(other.Body);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            Answer A = obj as Answer;

            return  this.Body == A.Body;
        }

        public override int GetHashCode()  // should be same as equal
        {
            return HashCode.Combine(Body);
        }

        public override string ToString()
        {
            return $"{Id}:{Body}";
        }




    }
}
