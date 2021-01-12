using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public class EarnerMoneyOnDie : MonoBehaviour
    {
        public IntVariable m_PlayerMoney;
        public int m_AddMoney = 25;

        private void OnDie()
        {
            if (TryGetComponent(out Team team) && GameManager.localTeam == team.data.name)
            {
                m_PlayerMoney.m_RuntimeValue += m_AddMoney;
            }
        }
    }
}
