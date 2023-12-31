﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FinalProject
{
    [XmlInclude(typeof(Jewelry))]
    [Serializable]
    public class JewelryStore
    {
        private int amountOfJewelries;
        private string address;
        private List<Jewelry> jewelryList;


        public string Address { get { return address; } set { address = value; } }

        public int AmountOfJewelries { get { return amountOfJewelries; } set { amountOfJewelries = value; } }

        public List<Jewelry> JewelryList { get { return jewelryList; } set { jewelryList = value; } }

        public JewelryStore() { }

        public JewelryStore(int amountOfJewelries, string address, List<Jewelry> jewelryList)
        {
            AmountOfJewelries = amountOfJewelries;
            Address = address;
            JewelryList = jewelryList;
        }

        public static JewelryStore InputFromFile(string path, string address)
        {
            

                List<Jewelry> jewelries = new List<Jewelry>();

                using (StreamReader sr = new StreamReader(path))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {

                        String[] jewelry = line.Split(' ');
                        if (address == jewelry[0])
                        {
                            string name = jewelry[1];
                            string metal = jewelry[2];
                            double weight = Double.Parse(jewelry[3]);
                            double price = Double.Parse(jewelry[4]);

                            jewelries.Add(new Jewelry(name, metal, weight, price));
                        }

                    }

                }
                int amountOfJewelries = jewelries.Count();
                return new JewelryStore(amountOfJewelries, address, jewelries);
            
            
        }

        public void Output()
        {
            Console.WriteLine($"JewelryStore at {Address} has  {amountOfJewelries} jewelries");
            foreach (var j in JewelryList)
            {
                Console.WriteLine($"{j.ToString()}");
            }
        }

        public void GetMetalsWithAmount(string path)
        {

            var metalCounts = jewelryList
                              .GroupBy(jewelry => jewelry.Metal)
                              .ToDictionary(group => group.Key, group => group.Count());

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                Console.WriteLine($"Metals with amount of jewelries in Jewelry Store at {Address}:");
                sw.WriteLine($"Metals with amount of jewelries in Jewelry Store at {Address}:");
                foreach (var kvp in metalCounts)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                    sw.WriteLine($"{kvp.Key}: {kvp.Value}");
                }
            }               
        }

        public static void GetStoresWithPriceGreater500(string path, JewelryStore[] stores)
        {

            var storesGreater500 = stores
                                   .Where(store => store.jewelryList
                                                   .Sum(jewelry => jewelry.Price) > 500);

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                Console.WriteLine($"List of Jewelry Stores with total jewelry's price greater than 500");
                sw.WriteLine($"List of Jewelry Stores with total jewelry's price greater than 500");
                foreach (var store in storesGreater500)
                {
                    sw.WriteLine($"\nJewelry Store at {store.Address} has:");
                    Console.WriteLine($"\nJewelry Store at {store.Address} has:");
                    store.JewelryList.Sort();
                    foreach (var j in store.JewelryList)
                    {
                        Console.WriteLine(j.ToString());
                        sw.WriteLine(j.ToString());
                    }
                }
            }
        }
    }
}
