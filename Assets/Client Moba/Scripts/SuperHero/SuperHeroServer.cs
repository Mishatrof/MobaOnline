using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperHeroServer : MonoBehaviour
{
    PhotonView photonView;
    NPCVisibleRangeFirstTarget visibleRange;


    void OnNewTarget()
    {
        photonView.RPC("OnSetTarget", RpcTarget.All, visibleRange.targetNetId);
    }

    void OnLostTarget()
    {
        photonView.RPC("OnSetTarget", RpcTarget.All, -1);
    }
}
