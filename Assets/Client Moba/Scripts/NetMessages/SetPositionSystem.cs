using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StaticSystems
{
    public struct SetPosition
    {
        public Vector3 pos;
        public int id;
    }

    public class SetPositionSystem : NetworkSystem<SetPosition>
    {
        public static void Add(int viewId, Vector3 position)
        {
            Add(new SetPosition { id = viewId, pos = position });
        }

        protected override void Run(List<SetPosition> dataList)
        {
            object[] data = new object[dataList.Count * 2];

            int i = 0;
            foreach (var item in dataList)
            {
                data[i++] = item.id;
                data[i++] = item.pos;
            }

            SendData(data, 100);
        }

        public override void OnEvent(EventData photonEvent)
        {
            if (photonEvent.Code != 100)
                return;

            var data = (object[])photonEvent.CustomData;

            for (int i = 0; i < data.Length;)
            {
                var viewId = (int)data[i++];
                var position = (Vector3)data[i++];

                var photonView = PhotonNetwork.GetPhotonView(viewId);
                photonView.transform.position = position;
            }
        }
    }
}
