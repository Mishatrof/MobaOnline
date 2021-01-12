using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomSerialization.Base
{
    public class BinaryFormat<T> : IFormatSerialize<T>
    {
        private readonly BinaryFormatter formatter;

        public BinaryFormat()
        {
            formatter = new BinaryFormatter();
        }

        public T Deserialize(Stream stream)
        {
            return (T)formatter.Deserialize(stream);
        }

        public void Serialize(Stream stream, T obj)
        {
            formatter.Serialize(stream, obj);
        }
    }
}
