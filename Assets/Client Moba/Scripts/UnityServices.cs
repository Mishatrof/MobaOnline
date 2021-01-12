using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityServices
{
    const string nameForScene = "UnityServices";

    public static GameObject GetKeeper()
    {
        var keeper = GameObject.Find(nameForScene);

        if (keeper == null)
        {
            keeper = new GameObject(nameForScene);
            Object.DontDestroyOnLoad(keeper);
        }

        return keeper;
    }

    public static T Get<T>() where T : Component
    {
        var keeper = GetKeeper();

        if (keeper.TryGetComponent(out T component))
            return component;
        else
            return keeper.AddComponent<T>();
    }
}
