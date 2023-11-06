using System.Xml.Serialization;
using static System.Formats.Asn1.AsnWriter;
using log4net;
using log4net.Config;
using System.Security.Cryptography.X509Certificates;

[assembly:log4net.Config.XmlConfigurator(Watch = true)]
namespace FinalProject
{
    
    internal class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                                                   (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void SerializeXML(string path, JewelryStore[] stores)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(JewelryStore[]));
            using (Stream serialStream = new FileStream(path, FileMode.Create))
            {
                xmlser.Serialize(serialStream, stores);
            };
            log.Debug("XML Serialization completed");
        }

        public static void DeserializeXML(string path, JewelryStore[] stores)
        {
            JewelryStore[] storesxml;
            XmlSerializer xmlser = new XmlSerializer(typeof(JewelryStore[]));
            using (Stream serialStream = new FileStream(path, FileMode.Open))
            {
                storesxml = xmlser.Deserialize(serialStream) as JewelryStore[];
            }
            log.Debug("XML Deserialization completed");

            foreach (var st in storesxml)
            {
                Console.WriteLine($"Deserialised Jewelry Store at {st.Address} has {st.AmountOfJewelries} jewelries:");
                foreach (var j in st.JewelryList)
                {
                    Console.WriteLine($"Deserialised: {j.ToString()}");
                }
                Console.WriteLine();
            };
        }

        static void Main(string[] args)
        {
            try {
                string readPath = @"D:\C# Fundamentals\FinalProject\Data\JewelryStores.txt";
                JewelryStore[] stores = new JewelryStore[4];
                String[] addresses = new String[4];
                addresses[0] = "Kovelska,1";
                addresses[1] = "Rivnenska,2";
                addresses[2] = "Lvivska,15";
                addresses[3] = "Lvivska,5";

                for (int i = 0; i < stores.Length; i++)
                {
                    stores[i] = JewelryStore.InputFromFile(readPath, addresses[i]);
                }
                foreach (var j in stores)
                {
                    j.Output();
                }
                Console.WriteLine("_________________________");

                string writePathMetalsWithAmount = @"D:\C# Fundamentals\FinalProject\Output files\metals_amount.txt";
                string writePathStoresWithJewelries = @"D:\C# Fundamentals\FinalProject\Output files\stores_jewelries.txt";

                stores[0].GetMetalsWithAmount(writePathMetalsWithAmount);
                Console.WriteLine("_________________________");

                JewelryStore.GetStoresWithPriceGreater500(writePathStoresWithJewelries, stores);
                Console.WriteLine("_________________________");

                Jewelry invalidJewelry = new Jewelry("ring", "ring", 3.0, 1000.0);
                Console.WriteLine("_________________________");

                // XML Serialization
                string pathSerialization = @"D:\C# Fundamentals\FinalProject\Output files\jewelry_stores.xml";
                SerializeXML(pathSerialization, stores);

                // XML Deserialization
                DeserializeXML(pathSerialization, stores);
                Console.WriteLine("_________________________");
            }
            

            catch (ArgumentException arge)
            {
                Console.WriteLine(arge.Message);
                log.Error(arge.Message);
            }

            catch(ApplicationException ae) 
            { 
                Console.WriteLine(ae.Message);
                log.Error(ae.Message);
            }

            catch(FileNotFoundException fe) 
            {
                Console.WriteLine(fe.Message);
                log.Error(fe.Message);
            }

            catch(IndexOutOfRangeException  ie)
            {
                Console.WriteLine(ie.Message);
                log.Error(ie.Message);
            }
        }
    }
}