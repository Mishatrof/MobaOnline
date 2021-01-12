using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deka : MonoBehaviour
{

    public Text NameText;
    public Text DamageText;
    public Text HealthText;
    public Text CostText;
    public Text SpellText;
    public Text RadiusText;
    public Text SpeedAttackText;
    public Text LuckText;
    public Image ImageCard;

    public void TakerInfo(Sprite img, string name, string Dmg, string hp, int cost, float rad, float speedAttack)
    {
        ImageCard.sprite = img;
        NameText.text = name;
        DamageText.text = "Атака: " + Dmg;
        HealthText.text = "Очки здоровья: " + hp;
        CostText.text = "Стоимость найма: " + cost;
        SpellText.text = "Маг.способности: Нет ";
        RadiusText.text = "Радиус обзора: " + rad;
        SpeedAttackText.text = "Скорость аттаки: " + speedAttack;
        LuckText.text = "Удача: 10% " ;

    }
}
