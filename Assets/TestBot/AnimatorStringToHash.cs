using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStringToHash : MonoBehaviour
{
    public string name1;

    [ContextMenu("ToHash")]
    void ToHash()
    {
        print(Animator.StringToHash(name1));
    }

}
