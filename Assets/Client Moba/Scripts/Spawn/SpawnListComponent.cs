using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UnitCommandId : byte
{
    SwitchFogOfWarScript
}

public struct UnitNetCommand
{
    public byte teamId;
    public int viewId;
    public string path;
}

public class UnitCommandsComponent : MonoBehaviour, IEnumerable<UnitNetCommand>
{
    public List<UnitNetCommand> list = new List<UnitNetCommand>(32);

    IEnumerator<UnitNetCommand> IEnumerable<UnitNetCommand>.GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return list.GetEnumerator();
    }
}
