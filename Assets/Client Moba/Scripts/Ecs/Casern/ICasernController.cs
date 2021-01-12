using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICasernController
{
    int indexLine { get; }

    void ReplaceMob(int index);
    List<Color> GetMobIcons();
}
