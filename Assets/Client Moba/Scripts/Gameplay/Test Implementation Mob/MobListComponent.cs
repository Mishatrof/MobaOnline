using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IMobState
{
    void OnEnter(MobComponent mob);
    MobStateEnum Update(MobComponent mob);
    void OnExit(MobComponent mob);
}

public enum MobStateEnum
{ None, MoveToPoint, Attack, Die }

public struct MobChangeStateInfo
{
    public MobComponent mob;
    public MobStateEnum exitState;
    public MobStateEnum enterState;
}

public class MobListComponent : MonoBehaviour
{
    public List<MobComponent> list;
    public List<MobComponent> moveToPointState { private set; get; } = new List<MobComponent>(64);
    public List<MobComponent> attackState { private set; get; } = new List<MobComponent>(32);
    public List<MobChangeStateInfo> changedState { private set; get; } = new List<MobChangeStateInfo>(32);


    public List<MobComponent> GetStateWithEnum(MobStateEnum state)
    {
        switch (state)
        {
            case MobStateEnum.MoveToPoint:
                return moveToPointState;
            case MobStateEnum.Attack:
                return attackState;
        }

        return null;

        // move to point+
        // attack+
        // chaged state
        //
        // idle-ish
    }
}