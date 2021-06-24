using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace InterimProjectUniversity
{
    public static class Builder<T>
    {
        static public List<T> Create(string path) 
        {
            List<T> createdObject;
            XmlSerializer formatter = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(path, FileMode.Open)) 
            {
                createdObject = (List<T>)formatter.Deserialize(fs);
            }
            return createdObject;
        }
    }
}
