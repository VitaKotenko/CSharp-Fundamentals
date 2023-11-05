using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace FinalProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readPath = @"D:\FinalProject\jewelry_store1.txt";
            JewelryStore[] stores = new JewelryStore[2];
            String[] addresses = new String[2];
            addresses[0] = "Zarina";
            addresses[1] = "Zarina1";


            for (int i = 0; i < stores.Length; i++)
            {
                stores[i] = JewelryStore.InputFromFile(readPath, addresses[i]);
            }
            foreach(var j in stores)
            {
                j.Output();

            }

            // XML Serialization
            XmlSerializer xmlser = new XmlSerializer(typeof(JewelryStore[]));
            using (Stream serialStream = new FileStream(@"D:\FinalProject\jewelry_stores.xml", FileMode.Create))
            {
                xmlser.Serialize(serialStream, stores);
            };

            JewelryStore[] storesxml;
            using (Stream serialStream = new FileStream(@"D:\FinalProject\jewelry_stores.xml", FileMode.Open))
            {
                storesxml = xmlser.Deserialize(serialStream) as JewelryStore[];
            };
            foreach(var st in storesxml) { 
                Console.WriteLine($"{st.Address} {st.AmountOfJewelries}"); 
                foreach(var j in st.JewelryList)
                {
                    Console.WriteLine(j.ToString());
                }
            };

            stores[0].GetMetalsWithAmount();

            JewelryStore.GetStoresWith(stores);








    }
    }
}