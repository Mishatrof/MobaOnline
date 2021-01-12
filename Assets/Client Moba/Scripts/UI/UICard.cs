using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public interface ICardOberver
{
    void OnClick(UICard card);
    void OnPointDown(UICard card);
    void OnPointUp(UICard card);
}

public class UICard : MonoBehaviour, IPointerClickHandler, 
    IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Text costText;
    public Text nameText;
    public Text damageText;
    public Text healthText;
    public Image iconMob;
    public Deka deka;
    public IntKristall kristal;
    


    public ICardOberver oberver;

    enum CardTtile
    {
        isUp,
        isDown
    };

    private CardTtile cardTtile;
    [System.NonSerialized] public UILobbyDeck parent;

    public void Start()
    {
        try
        {
            deka = FindObjectOfType<Deka>();
        }
        catch (Exception e)
        {
          
            throw;
        }
       
    }

    void Update()
    {
        if (deka == null)
        {
            kristal = FindObjectOfType<IntKristall>();
            if (kristal.m_Value < _mobPrefab.data.Cost)
            {
                iconMob.color = Color.grey;
            
            }

            else
            {
                iconMob.color = Color.white;
            }

        }
    }
    public MobDataReference mobPrefab
    {
        set
        {
            if (value != null) UpdateWidget(value);
            deka = FindObjectOfType<Deka>();
            _mobPrefab = value;
        }
        get { return _mobPrefab; }
    }

    public MobData mobData {
        set {
            if (value != null) {
                
            }
        }
        get { return cachedData; }
    }

    MobData cachedData;
    MobDataReference _mobPrefab;
    private IPointerEnterHandler pointerEnterHandlerImplementation;

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if (parent != null)
        {
            parent.selectedCard = this;
            parent.isClick = true;
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventdData)
    {
        if (deka == null)
        {
            gameObject.transform.position += new Vector3(0,50,0);
            cardTtile = CardTtile.isUp;
        }
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventdData)
    {
        if (deka == null)
        {
            gameObject.transform.position -= new Vector3(0,50,0);
            cardTtile = CardTtile.isDown;
        }
    }


    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {  
        oberver?.OnPointDown(this);
        if (cardTtile == CardTtile.isUp)
        {
            gameObject.transform.position -= new Vector3(0,50,0);
            cardTtile = CardTtile.isDown;
        }
        if (deka != null)
        {
          
            //deka = FindObjectOfType<Deka>();
            deka.TakerInfo(_mobPrefab.data.m_Sprite,
                _mobPrefab.data.name,
                _mobPrefab.data.Level[0].m_Damage.ToString(),
                _mobPrefab.data.Level[0].m_Health.ToString(),
                _mobPrefab.data.Cost, _mobPrefab.data.Radius,
                _mobPrefab.data.SpeedAttack);
        }


    }

    void  IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        oberver?.OnPointUp(this);
      
            gameObject.transform.position  = new Vector3(0,0,0);
        
            cardTtile = CardTtile.isDown;
            
            
       
        
    }

    void UpdateWidget(MobDataReference mob)
    {
        var data = mob.data;

        cachedData = data;

        costText.text = data.Cost.ToString();
        nameText.text = mob.name;
        iconMob.sprite = data.m_Sprite;

        if (data.Level.Count > 0)
        {
            damageText.text = "damage " + data.Level[0].m_Damage.ToString();
            healthText.text = "health " + data.Level[0].m_Health.ToString();
        }
    }

    
}
