using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task4.Helpers
{
    public class Helper
    {
        public static string resultTextForCarPark { get; set; } = "A car, produced by BMW with Petrol engine of 2,5 liters with 250 horse powers and serial number: 123, chassis with 4 wheels, maximal load of 4000 kilograms and serial number: 321, 2x2 transmission with 6 gears, pruduced by BMW, that can also carry 4 passengers" +
            "\nA bus, produced by Mercedes with Diesel engine of 6,2 liters with 385 horse powers and serial number: 777, chassis with 6 wheels, maximal load of 2000 kilograms and serial number: 751, 2x4 transmission with 7 gears, pruduced by Mercedes, that can also carry 48 passengers and has 2 ecological level" +
            "\nA lorry, produced by Citroen with Diesel engine of 5,45 liters with 350 horse powers and serial number: 500500, chassis with 4 wheels, maximal load of 1200 kilograms and serial number: 123789, 2x2 transmission with 6 gears, pruduced by Kia, that can also carry 5000 kilogramms" +
            "\nA scooter, produced by Ducati with Petrol engine of 2,2 liters with 290 horse powers and serial number: 222222, chassis with 2 wheels, maximal load of 250 kilograms and serial number: 123784, 1x1 transmission with 8 gears, pruduced by Ferrari, that can reach 100 km/h in just 5000 seconds, wow!" +
            "\nA car, produced by Mitsubishi with Hybrid engine of 1,1 liters with 90 horse powers and serial number: 123877, chassis with 4 wheels, maximal load of 4000 kilograms and serial number: 321, 2x2 transmission with 5 gears, pruduced by Mitsubishi, that can also carry 4 passengers\n";


        public static void XmlWriter<T>(List<T> objects, string fileName)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<T>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                writer.Serialize(fileStream, objects);
            }
        }

        public static List<T> XmlReader<T>(string fileName)
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<T>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                List<T> objects = (List<T>)reader.Deserialize(fileStream);
                return objects;
            }
        }
    }
}
