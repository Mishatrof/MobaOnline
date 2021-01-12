using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAsset.TestEntitas
{
    public abstract class MonoSystem : MonoBehaviour
    {
        public abstract void Execute(Context context);
    }
}
