using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILobbyDeck : MonoBehaviour
{
    public UICard cardPrefab;
    public Transform content;
    [System.NonSerialized] public UICard selectedCard;
    [System.NonSerialized] public UICard pointDownCard;
    [System.NonSerialized] public bool isClick;
}
