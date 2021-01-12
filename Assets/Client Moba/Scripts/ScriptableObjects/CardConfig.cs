using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Moba/CardConfig")]
public class CardConfig : ScriptableObject
{
    public MobDataReference defaultCardForCaserne;
    public MobDataReference[] defaultDeck;
    public MobDataReference[] allCards;
}
