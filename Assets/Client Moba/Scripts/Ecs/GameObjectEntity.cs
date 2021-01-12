using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class GameObjectEntity : MonoBehaviour, IEcsInitEntity
{
    public EcsEntity entity { private set; get; }
    public EcsWorld world { private set; get; }

    public T AddComponent<T>() where T : class, new()
    {
        return world.AddComponent<T>(entity);
    }

    public T EnsureComponent<T>() where T : class, new()
    {
        return world.EnsureComponent<T>(entity, out bool _);
    }

    public new T GetComponent<T>() where T : class, new()
    {
        return world.GetComponent<T>(entity);
    }

    void IEcsInitEntity.Init(EcsEntity entity, EcsWorld world)
    {
        this.entity = entity;
        this.world = world;
    }

    void Start()
    {
        if (entity.IsNull() || world == null)
        {
            Debug.LogError("Not init entity");
            Debug.Break();
        }
    }
}
