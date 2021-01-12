using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client.Game
{
    public class LineTrigger : MonoBehaviour
    {
        public int LineId;
        public GameObject View;
        public LineTrigger prevTrigger;

        public int countStayObj => _countStayObj >= COUNTFLAG ? _countStayObj - COUNTFLAG : _countStayObj;
        public bool isActive => View.activeSelf;

        int _countStayObj;
        const int COUNTFLAG = 10000;
        public bool isBoss = false;

     public void Start()
        {
            View.SetActive(false);
        }
        void OnTriggerEnter(Collider other)
        {
            if (!isBoss)
            {
                if (other.GetComponent<LineTriggerAgent>() == null) return;

                if (_countStayObj++ == 0)
                {
                    if (prevTrigger != null)
                    {
                        if (prevTrigger._countStayObj == 0) prevTrigger.View.SetActive(true);
                        prevTrigger._countStayObj += COUNTFLAG;
                    }

                    View.SetActive(true);
                }
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<LineTriggerAgent>() == null) return;

            if (--_countStayObj == 0)
            {
                if (prevTrigger != null)
                {
                    prevTrigger._countStayObj -= COUNTFLAG;
                    //if (prevTrigger._countStayObj == 0) prevTrigger.View.SetActive(false);
                }

                //View.SetActive(false);
            }
        }

        void OnEnable()
        {
           // View.SetActive(false);
            _countStayObj = 0;
        }
    }
}