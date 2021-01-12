using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDieNetMessage : MonoBehaviour
{
    public PhotonView photonView;

    void OnDie()
    {
        photonView.RPC("OnDie", RpcTarget.Others);
    }
}
