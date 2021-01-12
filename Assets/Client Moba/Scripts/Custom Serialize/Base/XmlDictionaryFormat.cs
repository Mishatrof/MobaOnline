using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CustomSerialization.Base
{
    public class XmlDictionaryFormat<T> : IFormatSerialize<Dictionary<string, T>>
    {
        public Dictionary<string, T> Deserialize(Stream stream)
        {
            using (XmlTextReader reader = new XmlTextReader(stream))
            {
                Dictionary<string, T> dict = new Dictionary<string, T>();

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Depth == 1)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T),
                            new XmlRootAttribute() { ElementName = reader.Name });

                        dict.Add(reader.Name, (T)serializer.Deserialize(reader));
                    }
                }

                return dict;
            }
        }

        public void Serialize(Stream stream, Dictionary<string, T> dict)
        {
            using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8) { Formatting = Formatting.Indented })
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("data");

                foreach (KeyValuePair<string, T> item in dict)
                {
                    XmlSerializer serializer = new XmlSerializer(item.Value.GetType(),
                        new XmlRootAttribute() { ElementName = item.Key.ToString() });
                    serializer.Serialize(writer, item.Value);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            };
        }
    }
}
