using System.IO;
using System.Xml.Serialization;

namespace Globals
{
    public static class Serializer
    {
        public static void Save<T>(T t, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(t.GetType());
            using (FileStream fs = File.Create(path))
            {
                xmlSerializer.Serialize(fs, t);
            }
        }

        public static T Load<T>(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream fs = File.OpenRead(path))
            {
                return (T)xmlSerializer.Deserialize(fs);
            }
        }

        public static T FromString<T>(string str)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (TextReader sr = new StringReader(str))
            {
                return (T)xmlSerializer.Deserialize(sr);
            }
        }

        public static string ToString<T>(T t)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            string str = string.Empty;
            using (TextWriter fs = new StringWriter())
            {
                xmlSerializer.Serialize(fs, t);
                str = fs.ToString();
            }
            return str;
        }

    }
}
