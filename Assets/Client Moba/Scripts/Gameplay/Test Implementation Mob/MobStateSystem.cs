using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobStateSystem : MonoBehaviour
{
    public MobListComponent m_MobList;

    public Dictionary<MobStateEnum, IMobState> m_States = new Dictionary<MobStateEnum, IMobState>(3);

    void Update()
    {
        UpdateState(m_MobList.moveToPointState, m_States[MobStateEnum.MoveToPoint]);

        UpdateChangedState();
    }

    void UpdateState(List<MobComponent> stateList, IMobState state)
    {
        for (int i = stateList.Count - 1; i >= 0; i--)
        {
            var mob = m_MobList.moveToPointState[i];
            var newStateEnum = state.Update(mob);

            if (newStateEnum != MobStateEnum.None)
            {
                ChangeState(MobStateEnum.MoveToPoint, newStateEnum, mob);
                m_MobList.moveToPointState.RemoveAt(i);
            }
        }
    }

    void UpdateChangedState()
    {
        if (m_MobList.changedState.Count == 0)
            return;

        foreach (var info in m_MobList.changedState)
        {
            m_States[info.exitState].OnExit(info.mob);
            m_States[info.enterState].OnEnter(info.mob);
        }

        m_MobList.changedState.Clear();
    }

    void ChangeState(MobStateEnum current, MobStateEnum news, MobComponent mob)
    {
        var info = new MobChangeStateInfo { mob = mob, enterState = news, exitState = current };
        m_MobList.changedState.Add(info);
    }
}
