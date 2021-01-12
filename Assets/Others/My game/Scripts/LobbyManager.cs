using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

namespace MyGame
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        // Start is called before the first frame update
        public Text TextLog;

        public override void OnConnectedToMaster()
        {
            Log("Connect to master...");
        }
        public override void OnCreatedRoom()
        {
            Log("Create room: TestRoom ...");
            PhotonNetwork.LoadLevel("Game");
        }

        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom("TestRoom", new Photon.Realtime.RoomOptions() { MaxPlayers = 2 });
        }
        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom("TestRoom");
        }
        void Start()
        {
            PhotonNetwork.NickName = "Player" + Random.Range(1, 999);
            Log("Start: Player name - " + PhotonNetwork.NickName);


            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = "0.1";
            PhotonNetwork.ConnectUsingSettings();
        }

        // Update is called once per frame
        private void Log(string message)
        {
            TextLog.text += message + "\n";
        }
    }
}
