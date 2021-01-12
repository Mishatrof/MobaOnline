using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Object = UnityEngine.Object;

namespace MyAsset.TestEntitas
{
    public class Context
    {
        private Dictionary<Type, List<IComponent>> components = new Dictionary<Type, List<IComponent>>();

        public GameObject Instantiate(GameObject original, Vector3 position, Quaternion rotation, Transform parent=null)
        {
            GameObject instance = GameObject.Instantiate(original, position, rotation, parent);

            foreach (var component in instance.GetComponents<IComponent>())
                AddComponent(component);

            foreach (var component in instance.GetComponentsInChildren<IComponent>())
                AddComponent(component);

            return instance;
        }

        public void Destroy(GameObject instance)
        {
            foreach (var component in instance.GetComponents<IComponent>())
                RemoveComponent(component);

            foreach (var component in instance.GetComponentsInChildren<IComponent>())
                RemoveComponent(component);

            GameObject.Destroy(instance);
        }

        public void AddComponent(IComponent component)
        {
            if (!components.ContainsKey(component.GetType()))
                components.Add(component.GetType(), new List<IComponent>());

            components[component.GetType()].Add(component);
        }

        public void RemoveComponent(IComponent component)
        {
            if (!components.ContainsKey(component.GetType()))
                return;

            components[component.GetType()].Remove(component);

            if (components[component.GetType()].Count == 0)
                components.Remove(component.GetType());
        }

        public List<T> GetComponents<T>() where T : class, IComponent
        {
            if (!components.ContainsKey(typeof(T)))
                return null;

            return components[typeof(T)].ConvertAll(item => item as T);
        }

        public IEnumerable<T> GetEnumerator<T>() where T : class, IComponent
        {
            if (!components.ContainsKey(typeof(T)))
                yield break;

            List<IComponent> tempList = components[typeof(T)];

            for(int i = 0; i < tempList.Count; i++)
                yield return tempList[i] as T;
        }
    }
}
