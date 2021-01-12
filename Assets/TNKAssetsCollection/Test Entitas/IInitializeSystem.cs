using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAsset.TestEntitas
{
    public interface IInitializeSystem
    {
        void Initialize(Context context);
    }
}
