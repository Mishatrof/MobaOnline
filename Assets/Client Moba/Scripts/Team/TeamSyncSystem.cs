using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamSyncSystem : MonoBehaviour, IOnEventCallback
{
    public TeamsComponent teamsComponent;

    static readonly float period = 0.5f;
    private float time;

    void OnEnable() { PhotonNetwork.AddCallbackTarget(this); }
    void OnDisable() { PhotonNetwork.RemoveCallbackTarget(this); }

    void IOnEventCallback.OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code != 150)
            return;

        var data = (object[])photonEvent.CustomData;

        for(int i = 0;  i < data.Length;)
        {
            var teamId = (byte)data[i++];

            var teamStats = teamsComponent.m_TeamsConfig[teamId];
            teamStats.experience = (int)data[i++];
            teamStats.level = (int)data[i++];
        }
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient == false)
            return;

        time += Time.deltaTime;
        if (time < period) return;
        time = 0f;


        for(int i = 0; i < teamsComponent.m_TeamsConfig.Count; i++)
        {
            var teamStats = teamsComponent.m_TeamsConfig[i];

            if (teamStats.isSync == false)
            {
                object[] data = new object[] { (byte)i, teamStats.experience, teamStats.level };
                SendData(data, 150);
                teamStats.isSync = true;
            }
        }
    }


    #region SendDataMethod
    static readonly RaiseEventOptions raiseOptions = new RaiseEventOptions
    {
        CachingOption = EventCaching.AddToRoomCache,
        Receivers = ReceiverGroup.Others,
    };

    static readonly SendOptions sendOptions = new SendOptions
    {
        Reliability = true
    };

    static void SendData(object[] data, byte id)
    {
        PhotonNetwork.RaiseEvent(id, data, raiseOptions, sendOptions);
    }
    #endregion
}
