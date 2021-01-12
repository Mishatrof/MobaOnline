using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public class InitCaserneArrayTask : MonoBehaviour
    {
        public TeamsComponent teamsComponent;

        public void Execute()
        {
            var sceneCasernes = GameObject.FindObjectsOfType<RPGGame.GameBase.GameBase>();

            for(int i = 0; i < teamsComponent.m_TeamsConfig.Count; i++)
            {
                var team = teamsComponent.m_TeamsConfig[i];
                var array = team.dataObject.GetComponent<CaserneArray>();
                array.value = new RPGGame.GameBase.GameBase[3];

                foreach(var caserne in sceneCasernes)
                {
                    if (caserne.GetComponent<Team>().teamId == i)
                    {
                        array.value[caserne.lineIndex] = caserne;
                    }
                }

#if DEBUG
                foreach(var caserne in array.value)
                    if (caserne == null) Debug.LogError("count casernes not equals three", gameObject);
#endif
            }
        }
    }
}
