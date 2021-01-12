using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAsset.Extensions
{
    public static class GameObjectExtension
    {
        public static bool GetComponent<T>(this GameObject gameObject, out T component) where T : Component
        {
            component = gameObject.GetComponent<T>();
            return component != null;
        }

        public static bool GetComponent<T>(this Component from, out T to) where T : Component
        {
            to = from.GetComponent<T>();
            return to != null;
        }
    }
}
