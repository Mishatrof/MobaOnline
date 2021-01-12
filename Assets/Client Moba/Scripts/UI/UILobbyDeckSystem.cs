using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Client.Lobby
{
    public class UILobbyDeckSystem : MonoBehaviourPunCallbacks
    {
        public UILobbyDeck playerDeck;
        public UILobbyDeck otherDeck;
        public SaveDeckTask saveDeckTask;

        PlayerSession playerSession;


        void Start()
        {
            playerSession = UnityServices.Get<PlayerSession>();
        }

        public void FillDecks()
        {
            for (int i = 0; i < playerSession.cardConfig.defaultDeck.Length; i++)
            {
                var tempCard = playerDeck.content.GetChild(i).GetComponent<UICard>();
                tempCard.mobPrefab = playerSession.cardConfig.defaultDeck[i];
                tempCard.parent = playerDeck;
            }

            saveDeckTask.Execute();

            foreach (var mob in playerSession.cardConfig.allCards)
            {
                var tempCard = Instantiate(otherDeck.cardPrefab, otherDeck.content);
                tempCard.mobPrefab = mob;
                tempCard.parent = otherDeck;
            }
        }

        public void ClearDecks()
        {
            foreach (Transform uicard in otherDeck.transform)
                Destroy(uicard.gameObject);
        }



        void Update()
        {
            if (playerDeck.gameObject.activeInHierarchy)
            {
                if (playerDeck.isClick)
                {
                    playerDeck.isClick = false;
                    otherDeck.gameObject.SetActive(true);
                }
            }


            if (otherDeck.gameObject.activeInHierarchy)
            {
                if (otherDeck.isClick)
                {
                    otherDeck.isClick = false;
                        // otherDeck.gameObject.SetActive(false);

                    var otherCard = otherDeck.selectedCard;
                    var playerCard = playerDeck.selectedCard;

                    if (otherCard != null && otherCard.mobPrefab != playerCard.mobPrefab)
                    {
                        playerCard.mobPrefab = otherCard.mobPrefab;
                        saveDeckTask.Execute();
                        otherDeck.selectedCard = null;
                    }
                }
            }
        }
    }
}