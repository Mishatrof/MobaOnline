using UnityEditor;
using UnityEngine;

public class IntInspectorField : GenericInspectorField<int>
{
    public override int ShowField(int value, GUIContent label)
    {
        return EditorGUILayout.IntField(label, value);
    }
}
