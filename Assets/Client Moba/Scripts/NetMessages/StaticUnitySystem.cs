using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class NetworkExtension
{
    static readonly RaiseEventOptions raiseOptions = new RaiseEventOptions
    {
        CachingOption = EventCaching.AddToRoomCache,
        Receivers = ReceiverGroup.All,
    };

    static readonly SendOptions sendOptions = new SendOptions
    {
        Reliability = true
    };

    static public void SendDataForSystem(object[] data, byte id)
    {
        PhotonNetwork.RaiseEvent(id, data, raiseOptions, sendOptions);
    }
}


public abstract class NetworkSystem<T> : StaticUnitySystem<T>, IOnEventCallback
{
    

    public static void SendData(object[] data, byte id)
    {
        NetworkExtension.SendDataForSystem(data, id);
    }

    public abstract void OnEvent(EventData photonEvent);

    protected void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    protected void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
}

public abstract class StaticUnitySystem<T> : MonoBehaviour
{
    static readonly List<T> dataList = new List<T>(32);

    static public void Add(T item)
    {
        dataList.Add(item);
    }

    protected abstract void Run(List<T> dataList);
    

    protected void Update()
    {
        if (dataList.Count > 0)
        {
            Run(dataList);
            dataList.Clear();
        }
    }
}
