using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using SimpleFogOfWar;
namespace RPGGame.GameBase
{
    [RequireComponent(typeof(Team))]
    public class GameBase : MonoBehaviourPun, ICasernController
    {
        public MineTeamComponent m_MineTeam;
        public Transform m_SpawnPoint;
        public Transform m_TargetPoint;
        public List<GameObject> m_SpawnMobs = new List<GameObject>(7);

        public bool isGlobal = false;

        //public TeamData m_TeamBase;

        Team teamComponent;

        public TeamData team => GetComponent<Team>().data;
        
        private  int TeamCount => GetComponent<Team>().teamId;
        public int lineIndex => m_LineIndex;

        [SerializeField]
        private int m_LineIndex = 0;
        //public string m_SetMobTag;

        private int m_ChangeMobIndex = 0;



        public void ChangeMob(string name)
        {
            if (!PhotonNetwork.IsMasterClient && PhotonNetwork.InRoom)
                photonView.RPC("OnChangeMob_RPC", RpcTarget.MasterClient, name);

            OnChangeMob_RPC(name);
            //m_SpawnMobs[index] = team.GetMobForGameBase(index);
        }


        public void SpawnMobs()
        {
            if (!enabled || !m_TargetPoint) return;
            foreach (GameObject mob in m_SpawnMobs) { SpawnMob(mob.name); }
        }

        void SpawnMob(string name)
        {
            SpawnMob(name, m_SpawnPoint.position + new Vector3(Random.value, 0f, Random.value) * Random.Range(-1.5f, 1.5f));
        }

        void SpawnMob(string name, Vector3 position)
        {
            object[] data = new object[] { (byte)teamComponent.teamId };
            GameObject newMob = PhotonNetwork.Instantiate(name, position, Quaternion.identity, 0, data);


            if (newMob.GetComponent<Mob>())
            {
                newMob.GetComponent<Mob>().SetDestination(m_TargetPoint.position);
             
            }

            var controller = newMob.GetComponent<Client.Game.NPCMobNetwork>();
            if (controller) controller.targetPoint = m_TargetPoint;
        }

        public void NetSpawnWave(string mobName, Vector3 positon, int count)
        {
            photonView.RPC("OnSpawnWaveOnlyOnLine", RpcTarget.MasterClient, mobName, positon, count);
        }
        
        [PunRPC]
        void OnSpawnWaveOnlyOnLine(string name, Vector3 positon, int count)
        {

            if (count == 4)
            {
               Vector3 pos = positon;
                for (int i = 0; i < 2; i++)
                {
                    
                    for (int j = 0; j < 2; j++)
                    { 
                        SpawnMob(name, pos);
                        pos.x += 1;
                    
                    }
                    pos.x = positon.x;
                    pos.z += 1;
                }
                
            }

            else{
                for (int i = 0; i < count; i++)
                {

                    SpawnMob(name, positon);

                }
            }
        }
        
        [PunRPC]
        void OnSpawnWave(string name, Vector3 positon)
        {
            for (int i = 0; i < 10; i++) SpawnMob(name, positon);
        }

        [PunRPC]
        private void OnChangeMob_RPC(string name)
        {
            var mobPrefab = Resources.Load<GameObject>(name);

            for (int i = 0; i < m_SpawnMobs.Count; i++)
                m_SpawnMobs[i] = mobPrefab;

            //m_SpawnMobs[m_ChangeMobIndex] = Resources.Load<GameObject>(name);

            //if (++m_ChangeMobIndex >= m_SpawnMobs.Count)
            //    m_ChangeMobIndex = 0;
        }

        private void Start()
        {
            m_MineTeam = FindObjectOfType<MineTeamComponent>();
        }
        //private void Start()
        //{
        //    GetComponent<MeshRenderer>().material = PhotonNetwork.IsMasterClient ? m_PlayerMaterial : m_EnemyMaterial;
        //}
        //void Awake()
        //{
        //    print("awake base");
        //}

        private void OnEnable()
        {
            //print("enable");
            //team.AddBase(this, m_LineIndex);
            if (isGlobal)
              team.casernes.Add(m_LineIndex, this);
        }

        private void OnDisable()
        {
            //team.RemoveBase(m_LineIndex);
            if (isGlobal)
              team.casernes.Remove(m_LineIndex);
        }

        void Awake()
        {
            teamComponent = GetComponent<Team>();

            m_SpawnMobs.Clear();
            for (int i = 0; i < 10; i++)
                m_SpawnMobs.Add(team.m_DefaultMob);
        }

        void OnDie()
        {
            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.Destroy(gameObject);
        }

        void ICasernController.ReplaceMob(int index)
        {
            throw new System.NotImplementedException();
        }

        List<Color> ICasernController.GetMobIcons()
        {
            return m_SpawnMobs.ConvertAll(mob => mob.GetComponent<MeshRenderer>().sharedMaterial.color);
        }

        int ICasernController.indexLine => m_LineIndex;
    }
}
