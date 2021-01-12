using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

namespace MyGame
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        public GameObject playerA;
        public GameObject playerB;
        public Transform camera;
        public Transform sPointA;
        public Transform sPointB;
        public UnityEngine.Events.UnityEvent m_StartGame;

        private GameObject tempPlayer;

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.LogFormat("Player {0} entered room", newPlayer.NickName);

            
            if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                photonView.RPC("OnStartGame", RpcTarget.All);
            }
        }


        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Debug.LogFormat("Player {0} left room", otherPlayer.NickName);
        }


        public void Leave()
        {
            PhotonNetwork.LeaveRoom();
        }


        public override void OnLeftRoom()
        {
            SceneManager.LoadScene("Lobby");
            PhotonNetwork.Destroy(tempPlayer);
        }


        public void OnApplicationQuit()
        {
            PhotonNetwork.DestroyAll();
        }


        [PunRPC]
        private void OnStartGame()
        {
            Vector3 position = PhotonNetwork.IsMasterClient ? sPointA.position : sPointB.position;
            GameObject player = PhotonNetwork.IsMasterClient ? playerA : playerB;

            GameObject newPlayer = PhotonNetwork.Instantiate(player.name, position, Quaternion.identity);
            camera.transform.SetParent(newPlayer.transform);
            camera.localPosition = new Vector3(0f, 0f, -10f);

            tempPlayer = player;

            m_StartGame.Invoke();
        }
    }


}
