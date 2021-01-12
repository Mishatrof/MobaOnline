using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Client.Lobby
{
    public class LobbyManager : MonoBehaviourPunCallbacks
    {
        // Start is called before the first frame update
        public InputField m_NickNameField;
        public Text TextLog;
        public string m_NameGameScene;

        [Header("Developent build")]
        public bool m_UseSencondPlayerOnStart = false;

        [Header("Tasks")]
        public SetSpeciesTask setSpecies;
        public UILobbyDeckSystem lobbyDeckSystem;


        //public override void OnRoomListUpdate(List<RoomInfo> roomList)
        //{
        //    string text = "";
        //    foreach (RoomInfo room in roomList)
        //    {
        //        print(room.ToStringFull());
        //    }

            
        //}

        public override void OnConnectedToMaster()
        {
            Log("Connect to master...");
            PhotonNetwork.JoinLobby();
        }


        public override void OnCreatedRoom()
        {
            Log("Create room...");
            SetTeamIndex_RPC(0);
        }

        public override void OnJoinedRoom()
        {
            Log("Joined room...");

            setSpecies.Execute();
            lobbyDeckSystem.FillDecks();
        }

        public override void OnLeftRoom()
        {
            lobbyDeckSystem.ClearDecks();
        }

        public override void OnJoinedLobby()
        {
            Log("OnJoinedLobby...");
        }


        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Log(returnCode + " " + message);
        }


        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                int teamIndex = PhotonNetwork.CurrentRoom.PlayerCount - 1;
                photonView.RPC("SetTeamIndex_RPC", newPlayer, (byte)teamIndex);
                Log_RPC("Connected new player: " + newPlayer.NickName + ", team: " + teamIndex);
            }
        }


        public void CreateRoom(string name, RoomOptions roomOptions)
        {
            PhotonNetwork.LocalPlayer.NickName = m_NickNameField.text;
            PhotonNetwork.CreateRoom(name, roomOptions);
        }


        public void JoinRoom(string name)
        {
            PhotonNetwork.LocalPlayer.NickName = m_NickNameField.text;
            PhotonNetwork.JoinRoom(name);
        }


        public void StartGame()
        {
            if (m_UseSencondPlayerOnStart && PhotonNetwork.CurrentRoom == null && PhotonNetwork.CurrentRoom.PlayerCount != 2)
            {
                Log("Error: Second player not connection or not create room");
                return;
            }

            if (!PhotonNetwork.IsMasterClient)
            {
                Log("Error: You not master client");
                return;
            }
            

            PhotonNetwork.LoadLevel(m_NameGameScene);
        }


        private void Start()
        {
            if (PhotonNetwork.IsConnected)
            {
                Log("Connected to master");
                Log("Player name: " + PhotonNetwork.NickName);
                m_NickNameField.text = PhotonNetwork.LocalPlayer.NickName;
            }
            else
            {
                m_NickNameField.text = "Player" + Random.Range(1, 9999);

                Log("Initialization...");
                Log("Player name: " + PhotonNetwork.NickName);
                Log("Waiting connection to master...");

                PhotonNetwork.AutomaticallySyncScene = true;
                //PhotonNetwork.GameVersion = "0.1";

                if (PhotonNetwork.OfflineMode) {
                    PhotonNetwork.Disconnect();
                    PhotonNetwork.OfflineMode = false;
                }

                PhotonNetwork.ConnectUsingSettings();
            }
        }

        
        [PunRPC]
        private void Log(string message)
        {
            TextLog.text += message + "\n";
        }

        
        private void Log_RPC(string message)
        {
            photonView.RPC("Log", RpcTarget.All, message);
        }

        [PunRPC]
        private void SetTeamIndex_RPC(byte index)
        {
            //ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
            //hashtable.Add('t', index);
            if (!PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("t"))
                PhotonNetwork.LocalPlayer.CustomProperties.Add("t", index);
            else
                PhotonNetwork.LocalPlayer.CustomProperties["t"] = index;

            Log("Your index team: " + index);
        }
    }


    [System.Serializable]
    public class LobbyEvents
    {
        public UnityEvent OnConnectedToMaster;
    }
}
