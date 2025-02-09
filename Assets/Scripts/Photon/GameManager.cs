﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerName;
    public Transform[] spawnPos;
    // Start is called before the first frame update
    void Start()
    {
      //  PhotonNetwork.Instantiate(PlayerName.name, spawnPos[0].position, spawnPos[0].rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} вошел в комнату", newPlayer.NickName);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} вышел из комнаты", otherPlayer.NickName);
    }
}
