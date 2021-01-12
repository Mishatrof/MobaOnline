using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextManager : MonoBehaviour
{
    ContextTest m_Context = new ContextTest();
    List<IUpdate> m_UpdateSystems = new List<IUpdate>(64);

    void Awake()
    {

    }


    void Update()
    {

    }
}

public interface IUpdate
{
    void Update(IContext context);
}


public interface IContext
{
    void AddUniqueComponent<T>(T component);
    bool HasUniqueComponent<T>(T component);
    void RemoveUniqueComponent<T>(T component);
    T GetUniqueComponent<T>(T component) where T : class;

}

public class ContextTest : IContext
{
    Dictionary<System.Type, object> UniqueComponents;

    void IContext.AddUniqueComponent<T>(T component)
    {
        UniqueComponents.Add(typeof(T), component);
    }

    T IContext.GetUniqueComponent<T>(T component)
    {
        return UniqueComponents[typeof(T)] as T;
    }

    bool IContext.HasUniqueComponent<T>(T component)
    {
        return UniqueComponents.ContainsKey(typeof(T));
    }

    void IContext.RemoveUniqueComponent<T>(T component)
    {
        UniqueComponents.Remove(typeof(T));
    }
}
