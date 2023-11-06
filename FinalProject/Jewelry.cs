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

            IsValid();
        }


        public void IsValid()
        {
            string[] validJewelries = { "necklace", "bracelet", "ring", "earrings"};
            string[] validMetals = { "gold", "silver", "platinum" };

            if (!validJewelries.Contains(name.ToLower()))
            {
                throw new ApplicationException("Jewelry must be necklace, bracelet, ring, or earrings");
            }
            
            if (!validMetals.Contains(metal.ToLower())) 
            {
                throw new ApplicationException("Metal must be gold, silver, or platinum");
            }

            if (weight <= 0 || weight > 50.0)
            {
                throw new ApplicationException("Weight must be between 0 and 50 g");
            }

            if (price <= 0)
            {
                throw new ApplicationException("Price must be higher than 0");
            }
        }


        public override string ToString()
        {
            return ($"Jewelry: {Name} was made from {Metal}, price: {Price} and weight: {Weight} g.");
        }


        public int CompareTo(Jewelry other)
        {
            Jewelry otherObject = (Jewelry)other;
            return this.Name.CompareTo(otherObject.Name);
        }   

    }
}

