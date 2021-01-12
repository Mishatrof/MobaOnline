using System;
using System.Collections;
using System.Collections.Generic;

public static class EventBus
{
    static Dictionary<Type, List<object>> Listeners = new Dictionary<Type, List<object>>(128);

    public static void AddListener<T>(T listener) where T : class
    {
        var type = typeof(T);

        if (Listeners.TryGetValue(type, out List<object> list))
            list.Add(listener);
        else
        {
            var newlist = new List<object>(8) { listener };
            Listeners.Add(type, newlist);
        }
    }

    public static void RemoveListener<T>(T listener)
    {
        var type = typeof(T);

        if (Listeners.TryGetValue(type, out List<object> list))
        {
            list.Remove(listener);

            if (list.Count == 0)
            {
                Listeners.Remove(type);
            }
        }
        else
            throw new ArgumentException("Non exixst key");
    }

    public static bool HasListener<T>()
    {
        return Listeners.ContainsKey(typeof(T));
    }

    public static void Raise<T>(Action<T> acion)
    {
        if (!HasListener<T>())
            return;

        foreach (T l in Listeners[typeof(T)])
            acion(l);
    }
}
