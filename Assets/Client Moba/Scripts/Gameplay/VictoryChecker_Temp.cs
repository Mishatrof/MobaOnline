using MyAsset;
using UnityEngine;



namespace RPGGame
{
    public class VictoryChecker_Temp : MonoBehaviour
    {
        [SerializeField]
        private TeamDataList m_TeamsList = null;
        [Header("Raise")]
        public BoolEvent m_GameOverEvent;


        void FixedUpdate()
        {
            foreach(var team in m_TeamsList)
            {
                if (team.casernes.Count == 0)
                {
                    
                    m_GameOverEvent.Raise(team != m_TeamsList.mineTeam);
                }
            }
        }
    }
}
