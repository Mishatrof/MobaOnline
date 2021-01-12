using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using UnityEngine;

namespace RPGGame
{
    public class Spell : MonoBehaviour, IXmlSerializable
    {
        [SerializeField]
        private int m_Cost = 10;


        public int cost { set { m_Cost = value; } get { return m_Cost; } }


        private void Start()
        {
            StartCoroutine(DestroyTimer());
        }


        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(5f);

            PhotonNetwork.Destroy(gameObject);
        }


        #region IXmlSerializable
        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            if (int.TryParse(reader.GetAttribute("cost"), out int cost))
                m_Cost = cost;
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("cost", m_Cost.ToString());
        }
        #endregion
    }
}
