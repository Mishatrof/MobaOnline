using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using SimpleFogOfWar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NetEventCode : byte
{
    SwitchFogScript, SyncUnitSpawnList
}

public class SpawnSystem : MonoBehaviour, IOnEventCallback
{
    public UnitCommandsComponent spawnListComponent;

    readonly static int countSyncField = 3;

    void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    object[] CopyToArray()
    {
        int dataSize = spawnListComponent.list.Count * countSyncField;
        object[] data = new object[dataSize];

        for(int i = 0; i < spawnListComponent.list.Count; i++)
        {
            var spawn = spawnListComponent.list[i];

            int idata = i * countSyncField;
            data[idata] = spawn.teamId;
            data[idata + 1] = spawn.viewId;
            data[idata + 2] = spawn.path;
        }

        return data;
    }

    void ExtractOfArray(object[] data)
    {
        for(int i = 0; i < data.Length; i += countSyncField)
        {
            spawnListComponent.list.Add(new UnitNetCommand {
                teamId =(byte)data[i],
                viewId =(int)data[i+1],
                path =  (string)data[i+2]
            });
        }
    }

    void Update()
    {
        if (spawnListComponent.list.Count > 0)
            SendData(CopyToArray());
    }


    void SendData(object[] data)
    {
        RaiseEventOptions raiseOptions = new RaiseEventOptions {
            CachingOption = EventCaching.AddToRoomCache,
            Receivers = ReceiverGroup.Others,
        };

        SendOptions sendOptions = new SendOptions {
            Reliability = true
        };

        PhotonNetwork.RaiseEvent((byte)NetEventCode.SwitchFogScript, data, raiseOptions, sendOptions);
    }

    void IOnEventCallback.OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code != (byte)NetEventCode.SyncUnitSpawnList)
            return;

        ExtractOfArray((object[])photonEvent.CustomData);
    }
}
