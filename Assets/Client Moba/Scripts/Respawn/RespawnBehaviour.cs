using Photon.Pun;
using StaticSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBehaviour : MonoBehaviour
{
    RespawnComponent respawnComponent;

    void Start()
    {
        respawnComponent = GetComponentInChildren<RespawnComponent>();
    }

    [ContextMenu("Respawn")]
    void OnRespawn()
    {
        var photonView = GetComponent<PhotonView>();
        SetPositionSystem.Add(photonView.ViewID, respawnComponent.point.position);
    }
}
