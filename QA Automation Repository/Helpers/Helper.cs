using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task4.Helpers
{
    public class Helper
    {
        public static void WriteToXmlFile<T>(List<T> objects, string fileName)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<T>));
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                writer.Serialize(fileStream, objects);
            }
        }

        public static List<T> ReadFromXmlFile<T>(string fileName)
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
