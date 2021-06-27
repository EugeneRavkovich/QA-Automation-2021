using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace Autopark
{
    public static class Serializer<T>
    { 
        public static void Serialize(string fileName, T obj)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate)) 
            {
                formatter.Serialize(fs, obj);
            }
        }


        public static void Serialize(string fileName, List<T> objects) 
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, objects);
            }
        }
    }
}
