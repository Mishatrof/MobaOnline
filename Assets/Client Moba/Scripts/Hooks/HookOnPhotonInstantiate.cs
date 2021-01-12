using MyAsset;
using Photon.Pun;
using UnityEngine;

public class HookOnPhotonInstantiate : MonoBehaviour, IPunInstantiateMagicCallback
{
    public GameObjectEvent m_OnInstantiated;

    void IPunInstantiateMagicCallback.OnPhotonInstantiate(PhotonMessageInfo info)
    {
        m_OnInstantiated.Raise(gameObject);
    }
}
