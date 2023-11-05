using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FinalProject
{
    [Serializable]
    public class Jewelry: IComparable<Jewelry>
    {
        private string name;
        private string metal;
        private double weight;
        private double price;


        public string Name { get { return name; } set { name = value; } }

        public string Metal { get { return metal; } set { metal = value; } }

        public double Weight { get { return weight; } set { weight = value; } }

        public double Price { get { return price; } set { price = value; } }

        public Jewelry() { }

        public Jewelry(string name, string metal, double weight, double price)
        {
            this.name = name;
            this.metal = metal;
            this.weight = weight;
            this.price = price;
        }


        public override string ToString()
        {
            return ($"Jewelry: {Name} was made from {Metal} cost: {Price} weight{Weight}");
        }


        public int CompareTo(Jewelry other)
        {
            Jewelry otherObject = (Jewelry)other;
            return this.Name.CompareTo(otherObject.Name);
        }

        
    }
}
