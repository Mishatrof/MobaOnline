using UnityEditor;
using UnityEngine;

public class FloatInspectorField : GenericInspectorField<float>
{
    public override float ShowField(float value, GUIContent label)
    {
        return EditorGUILayout.FloatField(label, value);
    }
}
