using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class SpellManager : MonoBehaviour
    {
        [SerializeField]
        private IntVariable m_PlayerMana;
        [SerializeField]
        private LayerMask m_LayerGround;

        public PhotonView m_PhotonView;
        public Transform m_Bloker;

        private Spell m_SelectedSpell;


        public void SetSpell(Spell spell)
        {
            m_SelectedSpell = spell;
        }

        public void EnableMakeSpellMode()
        {
            var canvast = GetComponentInParent<Canvas>().transform;
            m_Bloker.SetParent(canvast);
            m_Bloker.gameObject.SetActive(true);
        }

        public void DisableMakeSpellMode()
        {
            m_Bloker.SetParent(transform);
            m_Bloker.gameObject.SetActive(false);
        }


        public void MakeSpell()
        {
            if (m_SelectedSpell == null)
                return;

            if (m_PlayerMana.m_RuntimeValue < 50)
                return;

            m_PlayerMana.m_RuntimeValue -= m_SelectedSpell.cost;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, 1000f, m_LayerGround))
            {
                m_PhotonView.RPC("OnMakeSpellRPC", RpcTarget.MasterClient, m_SelectedSpell.name, hitInfo.point);
            }
        }


        [PunRPC]
        public void OnMakeSpellRPC(string name, Vector3 position)
        {
            GameObject newSpell = Resources.Load<GameObject>(name);

            PhotonNetwork.Instantiate(newSpell.name, position, Quaternion.identity);
        }
    }
}
