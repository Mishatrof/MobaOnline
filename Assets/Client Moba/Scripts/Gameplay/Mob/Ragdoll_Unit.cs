using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  Photon.Pun;
public class Ragdoll_Unit : MonoBehaviour
{
    private PhotonView PV;
    
    void Start()
    {
        PV = GetComponent<PhotonView>();
        Invoke("DestroyThis",10f);
    }

    public void DestroyThis()
    {
        PV.RPC("DestroyPUN_GameObject", RpcTarget.All);
    }
    [PunRPC]
    void DestroyPUN_GameObject()
    {PhotonNetwork.Destroy(gameObject);
    }
}
