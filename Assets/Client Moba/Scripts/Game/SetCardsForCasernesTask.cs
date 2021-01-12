using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public class SetCardsForCasernesTask : MonoBehaviour
    {
        public TeamsComponent teamsComponent;

        public void Execute()
        {
            var cardConfig = UnityServices.Get<PlayerSession>().cardConfig;


            for(int i = 0; i < teamsComponent.m_TeamsConfig.Count; i++)
            {
                var casernes = teamsComponent.m_TeamsConfig[i].dataObject.GetComponent<CaserneArray>().value;
                foreach(var caserne in casernes)
                {
                    caserne.ChangeMob(cardConfig.defaultCardForCaserne.name);
                }
            }
        }
    }
}