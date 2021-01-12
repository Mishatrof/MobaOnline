using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroOnDieNotify : MonoBehaviour
{
    public event System.Action onDie;

    public void OnDie()
    {
        onDie?.Invoke();
    }

    void OnDestroy()
    {
        onDie = null;
    }
}
