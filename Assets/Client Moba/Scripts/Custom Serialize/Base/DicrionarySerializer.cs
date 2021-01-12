using System.Collections.Generic;
using System.IO;

namespace CustomSerialization.Base
{
    public class DicrionarySerializer<T> : IFormatSerialize<Dictionary<string, T>>
    {
        private IFormatSerialize<Dictionary<string, T>> formatter;


        public DicrionarySerializer(Format format)
        {
            switch (format)
            {
                case Format.xml:
                    formatter = new XmlDictionaryFormat<T>();
                    break;
                case Format.bin:
                    formatter = new BinaryFormat<Dictionary<string, T>>();
                    break;
            }
        }

        public Dictionary<string, T> Deserialize(Stream stream)
        {
            return formatter.Deserialize(stream);
        }

        public void Serialize(Stream stream, Dictionary<string, T> dict)
        {
            formatter.Serialize(stream, dict);
        }
    }
}
