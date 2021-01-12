using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Photon.Pun;
using System.Xml.Serialization;
using System.Xml.Schema;

public abstract class Damager : MonoBehaviourPun, IXmlSerializable
{
    [SerializeField]
    private int m_Damage = 3;
    [SerializeField]
    private float m_HitSpeed = 0.5f;

    private List<HealthComponent> m_ViewTargets;

    private bool m_IsStateAttack = false;
    // private Coroutine m_HandleAttackClient;
    // private bool m_IsDistanceAttack = false;
    //  private MobHealth m_CurrentTarget;

    public int damage { set { m_Damage = value; } get { return m_Damage; } }
    public float hitSpeed { set { m_HitSpeed = value; } get { return m_HitSpeed; } }


    protected void Start()
    {
        m_ViewTargets = new List<HealthComponent>();
    }



    protected void OnTriggerEnter(Collider other)
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        if (CompareTag(other.tag))
            return;

        HealthComponent healthComponent = other.GetComponent<HealthComponent>();

        if (healthComponent == null)
            return;

        m_ViewTargets.Add(healthComponent);


        if (!m_IsStateAttack && gameObject.activeInHierarchy)
        {
            m_IsStateAttack = true;
            //photonView.RPC("AttackTargetRPC", RpcTarget.All, healthComponent.photonView.ViewID);
            StartCoroutine(HandleSelectionTargetServer());
        }
            
    }


    protected void OnTriggerExit(Collider other)
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        if (CompareTag(other.tag))
            return;

        HealthComponent healthComponent = other.GetComponent<HealthComponent>();

        if (healthComponent == null)
            return;

        m_ViewTargets.Remove(healthComponent);
    }


    private IEnumerator HandleSelectionTargetServer()
    {
        OnStartStateAttackServer();

        HealthComponent mobHealth = null;

        while (m_ViewTargets.Count > 0)
        {
            if (m_ViewTargets[0] == null || m_ViewTargets[0].isDied)
            {
                m_ViewTargets.RemoveAt(0);
                continue;
            }

            if (mobHealth != m_ViewTargets[0])
            {
                mobHealth = m_ViewTargets[0];
                photonView.RPC("OnNewTargetRPC", RpcTarget.All, mobHealth.photonView.ViewID);
                //StartCoroutine(HandleAttackClient(mobHealth));
            }
            

            //m_ViewTargets[0].SetDamage(m_Damage);
            yield return new WaitForSeconds(3f);
        }

        OnEndStateAttackServer();

        m_IsStateAttack = false;
    }

    private IEnumerator HandleAttackClient(HealthComponent mobHealth)
    {
        while (mobHealth != null && !mobHealth.isDied)
        {
            OnStayDamage(mobHealth);
            mobHealth.SetDamage(m_Damage);
            yield return new WaitForSeconds(m_HitSpeed);
        }
    }


    protected abstract void OnEndStateAttackServer();
    protected abstract void OnStartStateAttackServer();
    protected abstract void OnStayDamage(HealthComponent mobHealth);


    [PunRPC]
    protected void OnNewTargetRPC(int viewID)
    {
        PhotonView photonView = PhotonNetwork.GetPhotonView(viewID);
        HealthComponent mobHealth = photonView.GetComponent<HealthComponent>();

        StartCoroutine(HandleAttackClient(mobHealth));
    }


    #region IXmlSerializable
    XmlSchema IXmlSerializable.GetSchema()
    {
        return null;
    }

    void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
    {
        if (int.TryParse(reader.GetAttribute("damage"), out int damage))
            m_Damage = damage;
        if (float.TryParse(reader.GetAttribute("hit_speed"), out float hitSpeed))
            m_HitSpeed = hitSpeed;
    }

    void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
    {
        writer.WriteAttributeString("damage", m_Damage.ToString());
        writer.WriteAttributeString("hit_speed", m_HitSpeed.ToString());
    }
    #endregion
}
