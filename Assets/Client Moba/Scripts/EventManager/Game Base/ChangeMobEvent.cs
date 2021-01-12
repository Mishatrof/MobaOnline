using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyAsset;

namespace RPGGame.GameBase
{
    [CreateAssetMenu(menuName="Moba/Events/ChangeMob")]
    public class ChangeMobEvent : GameEvent<ChangeMobData>
    { }

    public struct ChangeMobData
    {
        public Team team;
        public int mobIndex;
        public int lineIndex;
    }
}
