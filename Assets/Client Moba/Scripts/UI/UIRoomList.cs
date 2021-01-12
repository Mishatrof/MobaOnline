using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRoomList : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text m_Text;


    private void Start()
    {
        m_Text.text = string.Empty;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(var room in roomList)
        {
            m_Text.text += room.Name + '\n';
        }
    }
}
