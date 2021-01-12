using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public interface IPlayerDeckObserver
{
    void OnPointDown(UIGamePlayerDeck playerDeck);
    void OnPointUp(UIGamePlayerDeck playerDeck);
}

public class UIGamePlayerDeck : MonoBehaviour, ICardOberver
{
    public UICard dragCard;
    public HorizontalLayoutGroup horizontalLayout;

    public IPlayerDeckObserver observer;

    public void ReplaceDragCard()
    {
        if (dragCard == null) return;

        transform.GetChild(5).gameObject.SetActive(true);
        dragCard.transform.SetSiblingIndex(6);
        dragCard.gameObject.SetActive(false);
        dragCard = null;
    }


    void ICardOberver.OnClick(UICard card)
    {
        
    }

    void ICardOberver.OnPointDown(UICard card)
    {
        dragCard = card;
        observer?.OnPointDown(this);
    }

    void ICardOberver.OnPointUp(UICard card)
    {
        if (dragCard == card)
        {
            observer?.OnPointUp(this);
            dragCard = null;
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            gameObject.GetComponent<HorizontalLayoutGroup>().enabled = false;
            gameObject.GetComponent<HorizontalLayoutGroup>().enabled = true;
            horizontalLayout.CalculateLayoutInputHorizontal();
            horizontalLayout.CalculateLayoutInputVertical();
            horizontalLayout.SetLayoutHorizontal();
            horizontalLayout.SetLayoutVertical();
        }
    }

    void Update()
    {
        if (dragCard != null)
        {
            dragCard.transform.position = Input.mousePosition;
        }
    }
}
