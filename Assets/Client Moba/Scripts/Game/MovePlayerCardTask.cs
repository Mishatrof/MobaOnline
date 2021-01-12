using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Client.Game
{
    public class MovePlayerCardTask : MonoBehaviour, IPlayerDeckObserver
    {
        public MineTeamComponent teamComponent;
        public TeamsComponent teamsComponent;
        public UIGamePlayerDeck playerDeck;
        //public GameObject lineTriggers;
        public IntKristall Kristal;

        public LayerMask lineTriggerMask;


        SpawnTriggers _spawnTriggers;
        Camera _camera;

        void Start()
        {
            playerDeck.observer = this;
            var sdata = GetComponentInParent<GameManager>().sceneData;
            _spawnTriggers = sdata.triggers;
            _camera = sdata.levelCamera;
            Kristal = FindObjectOfType<IntKristall>();
        }

        void IPlayerDeckObserver.OnPointDown(UIGamePlayerDeck playerDeck)
        {
            _spawnTriggers.gameObject.SetActive(true);
        }

        void IPlayerDeckObserver.OnPointUp(UIGamePlayerDeck playerDeck)
        {
            var ray = _camera.ScreenPointToRay(playerDeck.dragCard.transform.position);
            Debug.DrawRay(ray.origin, ray.direction * 100f);


            var cost = playerDeck.dragCard.mobPrefab.data.Cost;

#if DEBUG
            if (Kristal.m_Value < cost) { Debug.LogWarning("little money"); }
#endif


            if (Physics.Raycast(ray, out var hit, 1000f, lineTriggerMask) &&
                hit.collider.TryGetComponent(out LineTrigger trigger) &&
                trigger.countStayObj == 0 && trigger.isActive &&
                Kristal.m_Value >= cost)
            {
                var caserneArray = teamsComponent.m_TeamsConfig[teamsComponent.mineTeamId].dataObject.GetComponent<CaserneArray>().value;
                caserneArray[trigger.LineId].NetSpawnWave(playerDeck.dragCard.mobPrefab.name, trigger.transform.position, playerDeck.dragCard.mobPrefab.data.Cout);


                Kristal.m_Value -= cost;
                playerDeck.ReplaceDragCard();

#if DEBUG
                Debug.Log($"spawn wave on {trigger.LineId} line", trigger.gameObject);
#endif
            }
            else
                print("card hit to " + (hit.collider ? hit.collider.name : "none"));

            _spawnTriggers.gameObject.SetActive(false);
        }
    }
}
