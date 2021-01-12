using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Lobby
{
    public class SaveDeckTask : MonoBehaviour
    {
        public UILobbyDeck playerDeck;



        public void Execute()
        {
            var playerSession = UnityServices.Get<PlayerSession>();

            if (playerSession.lobbyDeck == null || playerSession.lobbyDeck.Length != 8)
                playerSession.lobbyDeck = new MobDataReference[8];

            for(int i = 0; i < playerSession.lobbyDeck.Length; i++)
            {
                var uicard = playerDeck.transform.GetChild(i).GetComponent<UICard>();

#if DEBUG
                if (uicard.mobPrefab == null) Debug.LogError("missing mobdata for uicard", uicard.gameObject);
#endif
                playerSession.lobbyDeck[i] = uicard.mobPrefab;
            }
        }
    }
}
