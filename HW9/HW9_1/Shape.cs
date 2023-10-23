using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    public abstract class Shape : IComparable
    {
        private string name;
        public string Name { get { return name; } }

        public Shape(string name)
        {
            this.name = name;
        }

        public abstract double Area();

        public abstract double Perimeter();

        public abstract string Output();


        public virtual int CompareTo(object compareObject)
        {
            Shape otherObject = (Shape)compareObject;
            return this.Area().CompareTo(otherObject.Area());
        }
    }
}
