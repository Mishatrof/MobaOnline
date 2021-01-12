using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Xml.Serialization;
using UnityEngine;

using Object = UnityEngine.Object;
using System.Xml;
using System.Text;

[CreateAssetMenu]
public class SaveData : ScriptableObject
{
    [Header("Сылки закидывать только с префабов")]
    [Header("В каждом ноде указывать уникальный ID")]
    [Header("ID указывать без пробелов и спец. символов")]
    [SerializeField]
    private string m_NameFile = "data.xml";
    [SerializeField]
    private List<NodeInfo> m_Nodes;


    [ContextMenu("Save")]
    public void Save()
    {
        using (XmlTextWriter writer = new XmlTextWriter(m_NameFile, Encoding.UTF8))
        {
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument();
            writer.WriteStartElement("Data");


            foreach (NodeInfo node in m_Nodes)
            {
                writer.WriteStartElement(node.nameId);

                foreach (SerializeObjectInfo serializeObject in node.serializeObjects)
                {
                    writer.WriteStartElement(serializeObject.nameId);

                    XmlSerializer serializer = new XmlSerializer(serializeObject.reference.GetType());
                    serializer.Serialize(writer, serializeObject.reference);

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        Debug.Log("Save file: " + Path.GetFullPath(m_NameFile));
    }

    [ContextMenu("Load")]
    public void Load()
    {
        using (XmlTextReader reader = new XmlTextReader(m_NameFile))
        {
            if(!reader.IsStartElement("Data"))
                throw new FileLoadException();


            SerializeObjectInfo serializeObject = null;
            NodeInfo node = null;

            while (reader.Read())
            {
                if (reader.Depth == 1 && reader.NodeType == XmlNodeType.Element)
                {
                    node = FindNode(reader.Name);
                }
                else if (reader.Depth == 2 && node != null)
                {
                    serializeObject = node.FindObject(reader.Name); 
                }
                else if (reader.Depth == 3 && serializeObject != null)
                {
                    XmlSerializer serializer = new XmlSerializer(serializeObject.reference.GetType());

                    if (serializer.CanDeserialize(reader))
                    {
                        if(serializeObject.reference is IXmlSerializable)
                        {
                            IXmlSerializable xmlSerializable = serializeObject.reference as IXmlSerializable;
                            xmlSerializable.ReadXml(reader);
                        }
                    }

                    serializeObject = null;
                }

                //NodeInfo node = FindNode(reader.Name);

                //reader.
            }
        }

        Debug.Log("Load file: " + Path.GetFullPath(m_NameFile));
    }


    private NodeInfo FindNode(string nameNode)
    {
        return m_Nodes.Find((node) => node.nameId.Equals(nameNode));
    }

    private object Find(string nameNode, string nameObject)
    {
        return null;
    }

    [Serializable]
    public class NodeInfo
    {
        public string nameId;
        public List<SerializeObjectInfo> serializeObjects;

        public SerializeObjectInfo FindObject(string name)
        {
            return serializeObjects.Find((obj) => obj.nameId.Equals(name));
        }
    }

    [Serializable]
    public class SerializeObjectInfo
    {
        public string nameId;
        public MonoBehaviour reference;
    }

}
