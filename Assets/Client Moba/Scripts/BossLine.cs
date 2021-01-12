using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLine : MonoBehaviour
{


    public float TimerMan;
    private float time  = 0;

    public Text text;
    public GameObject[] AllObj;

    public bool isOn;
    float timeZone = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Время до открытия зон: " + TimerMan;
        if (!isOn)
        {
            if (TimerMan >= time)
                TimerMan -= Time.deltaTime;
            else
            {
                isOn = true;
            }
        }
        if (isOn)
        {
            
            for (int i = 0; i < AllObj.Length; i++)
            {
                AllObj[i].SetActive(true);


            }

            timeZone -= Time.deltaTime;
            if(timeZone <= 0)
            {
               
                for (int i = 0; i < AllObj.Length; i++)
                {
                    AllObj[i].SetActive(false);

                }
                
                TimerMan = 20f;
                timeZone = 10f;
                isOn = false;
            }
        }
    
        

         

    }
}
