using System.IO;
using System;


namespace CustomSerialization.Base
{
    public interface IFormatSerialize<T>
    {
        void Serialize(Stream stream, T obj);
        T Deserialize(Stream stream);
    }


    [Serializable]
    public enum Format
    { bin, xml }
}
