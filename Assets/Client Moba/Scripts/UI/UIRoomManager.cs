using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Client.Lobby
{
    public class UIRoomManager : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        private LobbyManager m_LobbyManager;
        [SerializeField, Header("Connection")]
        private Text m_RoomListText;
        [SerializeField]
        private InputField m_NameRoomField;
        [SerializeField]
        private Transform m_RoomListContent;
        [SerializeField]
        private UIRoomItem m_RoomItemTemplate;

        [SerializeField, Header("Inside")]
        private Text m_RoomNameText;
        [SerializeField]
        private Text m_PlayerListText;

        public GameObject m_View;
        public GameObject m_ViewInside;

        private bool m_IsInside = false;


        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            UpdatePlayerList();
        }


        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            UpdatePlayerList();
        }


        List<RoomInfo> m_RoomListCache = new List<RoomInfo>(32);

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            string text = string.Empty;

            foreach(var uroom in roomList)
            {
                if (uroom.RemovedFromList)
                {
                    m_RoomListCache.Remove(uroom);
                }
                else
                {
                    if (!m_RoomListCache.Contains(uroom))
                    {
                        m_RoomListCache.Add(uroom);
                    }
                }
            }

            text += $"Count:{m_RoomListCache.Count}\n";

            foreach (RoomInfo room in m_RoomListCache)
                text += room.ToStringFull() + "\n";

            m_RoomListText.text = text + '\n';



            for (int i = 0; i < m_RoomListCache.Count; i++)
            {
                UIRoomItem item;
                

                if (i >= m_RoomListContent.childCount)
                {
                    item = Instantiate(m_RoomItemTemplate, m_RoomListContent);
                    item.SetJoinCallback(JoinRoom);
                }
                else
                {
                    item = m_RoomListContent.GetChild(i).GetComponent<UIRoomItem>();
                }

                item.SetRoomName(m_RoomListCache[i].Name);
            }

            for (int i = m_RoomListContent.childCount - 1; i >= m_RoomListCache.Count; i--)
            {
                Destroy(m_RoomListContent.GetChild(i).gameObject);
            }
        }

        public override void OnJoinedRoom()
        {
            m_View.SetActive(false);
            m_ViewInside.SetActive(true);
            m_IsInside = true;


            m_RoomNameText.text = PhotonNetwork.CurrentRoom.Name;
            UpdatePlayerList();
        }

        public override void OnLeftRoom()
        {
            m_View.SetActive(true);
            m_ViewInside.SetActive(false);
            m_IsInside = false;
        }


        public override void OnDisconnected(DisconnectCause cause)
        {
            m_View.SetActive(false);
            m_ViewInside.SetActive(false);
            m_IsInside = false;
        }


        public override void OnJoinedLobby()
        {
            m_View.SetActive(true);
            m_ViewInside.SetActive(false);
            m_IsInside = false;
        }


        public void CreateRoom()
        {
            m_LobbyManager.CreateRoom(m_NameRoomField.text, new RoomOptions() { MaxPlayers = 2, IsVisible = true, IsOpen = true, EmptyRoomTtl = 10});
        }

        public void JoinRoom(string name)
        {
            m_LobbyManager.JoinRoom(name);
        }


        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom(false);
        }


        private void Start()
        {
            //m_RoomListText.text = string.Empty;
            //m_View = transform.Find("View Connection");
            //m_ViewInside = transform.Find("View Inside");

            OnDisconnected(new DisconnectCause());
        }

        private void UpdatePlayerList()
        {
            string text = string.Empty;

            foreach(var player in PhotonNetwork.CurrentRoom.Players)
            {
                text += player.Value.NickName + '\n';
            }

            m_PlayerListText.text = text;
        }
    }
}
