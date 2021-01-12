using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SuperHeroControll : MonoBehaviour, IPointerClickHandler
{
    public TeamsComponent m_TeamsComponent;
    public Transform m_Bloker;
    public LayerMask m_GroundLayer;
    public LayerMask m_SupeHeroLayer;
    public PhotonView m_PhotonView;
    public UITimerSlider m_TimerRespawnHero;
    public Button m_SendHeroButton;
    public GameObject m_UnitMarkerPrefab;

    public bool isEnabledSendMode { private set; get; }

    //List<GameObject> m_Heroes = new List<GameObject>(2);
    //List<RebornSuperHeroInfo> m_RebornList = new List<RebornSuperHeroInfo>(2);

    GameObject m_MineHero;
    PhotonView m_MineHireNetView;

    GameObject m_SelectedHero;
    

    public void EnableSendHeroMode()
    {
        var canvas = GetComponentInParent<Canvas>().transform;
        m_Bloker.SetParent(canvas);
        m_Bloker.gameObject.SetActive(true);

        isEnabledSendMode = true;
    }

    public void CancelSendHeroMode()
    {
        m_Bloker.SetParent(transform);
        m_Bloker.gameObject.SetActive(false);

        isEnabledSendMode = false;
    }

    public void OnClickBloker()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo , 1000f, m_GroundLayer);

        if (hitInfo.collider == null)
            return;


        //photonView.RPC("SendHero", RpcTarget.MasterClient, (byte)m_TeamsComponent.mineTeamId, hitInfo.point);
        SendHero(hitInfo.point);
        CancelSendHeroMode();
    }


    public void OnDieSuperHero()
    {
        m_TimerRespawnHero.StartTimer(15f);
        Invoke("OnEndTimerRespawn", 15f);

        //m_MineHireNetView.RPC("SetActive", RpcTarget.All, false);

        if (isEnabledSendMode)
            CancelSendHeroMode();

        m_SendHeroButton.interactable = false;
    }

    public void OnEndTimerRespawn()
    {
        //m_MineHireNetView.RPC("SetActive", RpcTarget.All, true);

        //SpawnSuperHeroes();
        m_SendHeroButton.interactable = true;
    }

    void SendHero(Vector3 point)
    {
        var hero = m_MineHero.GetComponent<NPCSuperHeroNetwork>();
        hero.NetSetDistination(point);
    }


    void Start()
    {
        SpawnSuperHeroes();

        m_SendHeroButton.interactable = true;
    }

    void SpawnSuperHeroes()
    {

        var spawnPoint = m_TeamsComponent.mineTeam.SpawnPointSuperHero;
        var prefab = m_TeamsComponent.mineTeam.PrefabSuperHero;
        

        m_MineHero = PhotonNetwork.Instantiate(prefab.name, spawnPoint.position, spawnPoint.rotation);
        m_MineHireNetView = m_MineHero.GetComponent<PhotonView>();

        var respawnComponent = m_MineHero.GetComponentInChildren<RespawnComponent>();
        respawnComponent.point = spawnPoint;

        HeroOnDieNotify onDieNotify;

        if (m_MineHero.TryGetComponent(out HeroOnDieNotify onDieNotify1))
            onDieNotify = onDieNotify1;
        else
            onDieNotify = m_MineHero.AddComponent<HeroOnDieNotify>();

        onDieNotify.onDie += OnDieSuperHero;
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1) // lmb
        {
            if (SearchSuperHero(out GameObject newhero))
            {
                if (newhero == m_SelectedHero)
                    return;

                var newmarker = Instantiate(m_UnitMarkerPrefab, newhero.transform.position, Quaternion.identity);
                newmarker.transform.SetParent(newhero.transform);
                newmarker.name = "UnitMarker";

                if (m_SelectedHero != null)
                {
                    var marker = m_SelectedHero.transform.Find("UnitMarker").gameObject;
                    Destroy(marker);
                }

                m_SelectedHero = newhero;

            }
            else if(m_SelectedHero != null)
            {
                var marker = m_SelectedHero.transform.Find("UnitMarker").gameObject;
                Destroy(marker);
                m_SelectedHero = null;
            }
        }
        else if (eventData.pointerId == -2) // rmb
        {
            if (m_SelectedHero != null)
            {
                SendSuperHero();
            }
        }
    }

    void CancelSelectedHero()
    {

    }

    bool SearchSuperHero(out GameObject searchHero)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        searchHero = null;

        Debug.DrawRay(ray.origin, ray.direction * 100f);

        if(Physics.Raycast(ray, out var hitInfo, 1000f, m_SupeHeroLayer) && hitInfo.rigidbody.CompareTag("SuperHero"))
        {
            searchHero = hitInfo.rigidbody.gameObject;
            return true;
        }

        return  false;
    }

    void SendSuperHero()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, 1000f, m_GroundLayer))
        {
            var hero = m_SelectedHero.GetComponent<NPCSuperHeroNetwork>();
            hero.NetSetDistination(hitInfo.point);
        }
    }
}

public struct RebornSuperHeroInfo
{
    public float RemainedTime;
    public byte TeamId;
}
