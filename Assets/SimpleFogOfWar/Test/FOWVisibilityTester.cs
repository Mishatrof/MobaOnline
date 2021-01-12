using System;
using UnityEngine;

namespace SimpleFogOfWar.Test
{
    public class FOWVisibilityTester: MonoBehaviour
    {

        FogOfWarSystem fow;
        public GameObject View;
        Color gizmoColor;

        void Start()
        {
            fow = FindObjectOfType<FogOfWarSystem>();
        }

        void Update()
        {
            if (!fow) return;
            var fv = fow.GetVisibility(transform.position);
            switch (fv)
            {
                case FogOfWarSystem.FogVisibility.Undetermined:
                    Debug.Log("Inv");
                   // gizmoColor = Color.white;
                    break;
                case FogOfWarSystem.FogVisibility.Visible:
                    View.SetActive(true);
                    break;
                case FogOfWarSystem.FogVisibility.Invisible:
                    View.SetActive(false);
                    break;
            }
        }

     

    }
}
