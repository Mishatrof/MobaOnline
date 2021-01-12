using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public class SetPlayerDeckTask : MonoBehaviour
    {
        public UIGamePlayerDeck playerDeck;

        public void Execute()
        {
            var playerSession = UnityServices.Get<PlayerSession>();

            var deck = playerSession.lobbyDeck == null ? 
                playerSession.cardConfig.defaultDeck : 
                playerSession.lobbyDeck;

            for(int i = 0; i < deck.Length; i++)
            {
                var tcard = playerDeck.transform.GetChild(i).GetComponent<UICard>();
                tcard.mobPrefab = deck[i];
                tcard.oberver = playerDeck;
            }
        }
    }
}