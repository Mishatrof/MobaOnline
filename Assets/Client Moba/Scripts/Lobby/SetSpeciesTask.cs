using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpeciesTask : MonoBehaviourPunCallbacks
{
    public CardConfig orksCards;
    public CardConfig peopleCards;

    [Header("Debug")]
    public CardConfig forciblySpecies;

    public void Execute()
    {
#if DEBUG
        if (forciblySpecies != null)
        {
            UnityServices.Get<PlayerSession>().cardConfig = forciblySpecies;
            return;
        }
#endif

        UnityServices.Get<PlayerSession>().cardConfig = orksCards;
           // !PhotonNetwork.IsMasterClient ? peopleCards : peopleCards;
    }
}
