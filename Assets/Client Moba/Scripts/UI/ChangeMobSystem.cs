using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using MyAsset;
using System;

using UnityEngine.EventSystems;

namespace RPGGame
{
    public class ChangeMobSystem : MonoBehaviour, IUpdateMobsListForCasernesListener
    {
        //[SerializeField]
        //private GameManager m_GameManager;
        [SerializeField]
        private UIMobIconInCaserne m_UIMobIcons;
        [SerializeField]
        private TeamDataList m_TeamsList;
        [SerializeField]
        private GameObjectList m_GameBasesList;
        public MineTeamComponent m_MineTeam;
        public IntVariable m_Money;
        public GameObject O_Money;
        public AudioSource AS;
        public AudioClip Buy_Sound;
        public AudioClip Error;
        //[SerializeField]
        //private TeamData m_MineTeam;

        public RectTransform m_SelectionMobButtons;

        private GameBase.GameBase m_SelectedBase;
        //private int m_SelectionIndex = 0;
        MobsForFillsCasernes m_MobsForFillsCasernes;

        public void Start()
        {
            m_MobsForFillsCasernes = FindObjectOfType<MobsForFillsCasernes>();
            SetSelectLine(1);
            AS = GetComponent<AudioSource>();


        }
 

        public void ChangeMob(int index)
        {
            print(m_SelectedBase == null);

            if (m_SelectedBase == null)
                return;
            if (m_Money.m_RuntimeValue < 50)
            {
                AS.PlayOneShot(Error);
                return;
            }

             Debug.Log(m_SelectedBase.m_SpawnMobs[index].name);
              Debug.Log(m_MobsForFillsCasernes.mobs[index].name);
        
                    m_Money.m_RuntimeValue -= 50;
               
                    m_Money.m_RuntimeValue -= 75;
                   
        
              
                AS.PlayOneShot(Buy_Sound);
            
            m_SelectedBase.ChangeMob(m_MobsForFillsCasernes.mobs[index].name);
            UpdateIcons();
        }

        public void SetSelectLine(int indexBase)
        {
            m_SelectedBase = null;

            if (m_TeamsList.GetTeam(m_MineTeam.teamId).casernes
                .TryGetValue(indexBase, out GameBase.GameBase gameBase))
            {
                m_SelectedBase = gameBase;
                UpdateIcons();
            }
            else
                throw new Exception("Not find Caserne");
        }


        private void UpdateIcons()
        {
            Sprite Convert(GameObject mob)
            {
                return mob.GetComponent<MobDataReference>().data.m_Sprite;
            }

            List<Sprite> colorList = m_SelectedBase.m_SpawnMobs.ConvertAll(Convert);
            
            m_UIMobIcons.UpdateCells(colorList);
        }


        void OnEnable()
        {
            EventBus.AddListener<IUpdateMobsListForCasernesListener>(this);
        }

        void OnDisable()
        {
            EventBus.RemoveListener<IUpdateMobsListForCasernesListener>(this);
        }


        void IUpdateMobsListForCasernesListener.ChangedList(MobsForFillsCasernes list)
        {
            print("update");

            foreach (Transform buttont in m_SelectionMobButtons)
                buttont.gameObject.SetActive(false);

            for (int i = 0; i < list.mobs.Count; i++)
            {
                var mobData = list.mobs[i].GetComponent<MobDataReference>().data;

                m_SelectionMobButtons.GetChild(i).GetChild(0).GetComponent<Image>().sprite = mobData.m_Sprite;
                m_SelectionMobButtons.GetChild(i).gameObject.SetActive(true);
            }

            
        }
    }
}
