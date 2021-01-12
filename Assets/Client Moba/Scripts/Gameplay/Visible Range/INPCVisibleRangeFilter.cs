using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCVisibleRangeFilter
{
    bool Execute(Rigidbody target);
}
