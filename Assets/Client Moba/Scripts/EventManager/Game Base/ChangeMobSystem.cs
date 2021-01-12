using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyAsset;

namespace RPGGame.GameBase
{
    [RequireComponent(typeof(Team))]
    [RequireComponent(typeof(GameBase))]
    public class ChangeMobSystem : MonoBehaviour, IListener<ChangeMobData>
    {
        [SerializeField]
        private ChangeMobEvent m_ChangeMobEvent;

        private void OnEnable()
        {
            m_ChangeMobEvent.AddListener(this);
        }

        private void OnDisable()
        {
            m_ChangeMobEvent.RemoveListener(this);
        }

        void IListener<ChangeMobData>.OnInvoke(ChangeMobData arg)
        {
            throw new System.NotImplementedException();
        }
    }
}
