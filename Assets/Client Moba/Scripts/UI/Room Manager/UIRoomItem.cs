using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRoomItem : MonoBehaviour
{
    [SerializeField]
    private Text m_NameRoomText;
    [SerializeField]
    private Button m_JoinButton;

    private Action<string> m_JoinCallback;
    

    public bool interactable
    {
        set
        {
            m_JoinButton.interactable = value;

            if (!value)
            {
                m_NameRoomText.text = "Empty";
            }
        }
    }


    public void SetJoinCallback(Action<string> callback)
    {
        m_JoinCallback = callback;
    }

    public void SetRoomName(string name)
    {
        m_NameRoomText.text = name;
    }


    public void Join()
    {
        m_JoinCallback(m_NameRoomText.text);
    }
}
