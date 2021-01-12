using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public interface IEcsInitEntity
{
    void Init(EcsEntity entity, EcsWorld world);
}
