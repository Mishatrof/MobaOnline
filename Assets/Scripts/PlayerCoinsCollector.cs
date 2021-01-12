using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCoinsCollector : MonoBehaviour
{
    public Text textCoins;
    public int countCoins;
    public string tagCoins;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(tagCoins))
            return;

        countCoins++;

        if (textCoins)
            textCoins.text = countCoins.ToString();
    }
}
