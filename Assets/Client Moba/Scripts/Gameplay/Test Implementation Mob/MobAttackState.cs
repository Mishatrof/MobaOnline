using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttackState : MonoBehaviour, IMobState
{
    void IMobState.OnEnter(MobComponent mob)
    {
        throw new System.NotImplementedException();
    }

    MobStateEnum IMobState.Update(MobComponent mob)
    {
        throw new System.NotImplementedException();
    }

    void IMobState.OnExit(MobComponent mob)
    {
        throw new System.NotImplementedException();
    }

    void OnEnable()
    {
        GetComponent<MobStateSystem>().m_States
            .Add(MobStateEnum.Attack, this);
    }

    void OnDisable()
    {
        GetComponent<MobStateSystem>().m_States
            .Remove(MobStateEnum.Attack);
    }
}
