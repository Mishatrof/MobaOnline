using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System;
using MyAsset;
using UnityEngine.SceneManagement;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using UnityEngine.AI;

namespace Client.Game
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        public VisualTextTimer m_Timer;
        //public List<GameBase> m_GameBases;
        //public List<GameBase> m_PlayerBase;

        //public TeamData m_TeamA;
        //public TeamData m_TeamB;
        public TeamDataList m_TeamsList;

        public float m_DeltaTimeSpawn = 5f;
        public IntVariable m_PlayerMoney;
        //public List<GameAction> m_InitGameActions;

        [Header("Game Events")]
        [SerializeField]
        private VoidEvent m_SpawnMobsEvent = null;

        [Header("Tasks")]
        public SetPlayerDeckTask setPlayerDeck;
        public InitCaserneArrayTask initCaserneArray;
        public SetCardsForCasernesTask setCardsForCasernes;
        public InitSpawnTriggersTask initSpawnTriggers;

        [Header("Developent build")]
        public bool m_SpawnOnStart = false;

        public SceneData sceneData { private set; get; }

        public static string localTeam { private set; get; }
        public static int mineTeamId { private set; get; }
        //public static TeamData mineTeam { private set; get; }


        public void StartGame()
        {
            if (PhotonNetwork.IsMasterClient)
                StartCoroutine(SpawnMobsHandler());
        }

        public void LeaveGame()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene("Lobby");
        }


        // Start is called before the first frame update
        void Awake()
        {
            NavMesh.pathfindingIterationsPerFrame = 500;
            m_TeamsList.SetMineTeam(PhotonNetwork.LocalPlayer);

            InitMineTeam();

            var sdata = FindObjectOfType<SceneData>();

#if DEBUG
            if (sdata == null) Debug.Log("not find scene data component", gameObject);
#endif
            sceneData = sdata;

            initCaserneArray.Execute();
            setPlayerDeck.Execute();
            setCardsForCasernes.Execute();
            initSpawnTriggers.Execute(sdata.triggers);
        }

        void Start()
        {
            InitMobsForFillsCasernes();

        }

        void InitMineTeam()
        {
            var mineTeam = GetComponentInChildren<MineTeamComponent>();
            int id = 0;

            if (PhotonNetwork.IsConnectedAndReady)
            {
                id = PhotonNetwork.IsMasterClient ? 0 : 1;
            }
            else
            {
                id = mineTeam.offlineId;
            }


            mineTeamId = id;
            mineTeam.teamId = id;
            var teamsConfig = GetComponentInChildren<TeamsComponent>();
            teamsConfig.mineTeamId = id;

            localTeam = m_TeamsList.GetTeam(id).name;
        }

        void InitMobsForFillsCasernes()
        {
            var mobList = GetComponentInChildren<MobsForFillsCasernes>();
            mobList.mobs.Add(m_TeamsList.mineTeam.m_DefaultMob);
            EventBus.Raise<IUpdateMobsListForCasernesListener>(l => l.ChangedList(mobList));
        }


        private IEnumerator SpawnMobsHandler()
        {
            if (m_SpawnOnStart)
            {
                m_SpawnMobsEvent.Raise();
            }

            while (true)
            {
                photonView.RPC("OnStartTimer_RPC", RpcTarget.All);
                yield return new WaitForSeconds(m_DeltaTimeSpawn);
               // m_PlayerMoney.m_RuntimeValue -= 210;
                m_SpawnMobsEvent.Raise();
            }
        }


        [PunRPC]
        private void OnStartTimer_RPC()
        {
            m_Timer.StartTimer(m_DeltaTimeSpawn);
        }
    }
}
