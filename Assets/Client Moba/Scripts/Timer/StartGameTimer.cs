using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using MyAsset;
using Photon.Pun;

public class StartGameTimer : Timer
{
    [SerializeField]
    private float m_Time;
    [SerializeField]
    private Text m_Text;
    //[SerializeField]
    //private Image m_Background;
    //[SerializeField]
    //private AnimationCurve m_AnimationAlphaBackground;
    [SerializeField]
    private VoidEvent m_StartGame;

    [SerializeField]
    public List<Text> m_AnimAlphaTexts;
    [SerializeField]
    private Text m_MineNicknameText;
    [SerializeField]
    private Text m_EnemyNicnnameText;


    protected void Start()
    {
        if (PhotonNetwork.InRoom)
            InitNicknames();
        StartTimer(m_Time);

        transform.Find("View").gameObject.SetActive(true);
    }

    protected override void OnTickTimer(float remainedTime, float startTime)
    {
        m_Text.text = remainedTime.ToString("00");

        foreach (var text in m_AnimAlphaTexts)
        {
            Color ca = text.color;
            ca.a = remainedTime / startTime;
            text.color = ca;
        }

        //Color color = m_Background.color;
        //color.a = m_AnimationAlphaBackground.Evaluate(remainedTime / startTime);
        //m_Background.color = color;
    }

    protected override void OnStopTimer()
    {
        m_Text.text = "00";
        m_StartGame.Raise();
    }


    void InitNicknames()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount != 2)
        {
            Debug.LogWarning("Error set nacknames, player count not equals two");
            return;
        }


        foreach (var player in PhotonNetwork.CurrentRoom.Players)
        {
            if (player.Value == PhotonNetwork.LocalPlayer)
                m_MineNicknameText.text = player.Value.NickName;
            else
                m_EnemyNicnnameText.text = player.Value.NickName;
        }
    }
}
