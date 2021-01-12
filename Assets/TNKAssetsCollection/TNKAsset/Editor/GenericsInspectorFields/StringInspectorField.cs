using UnityEditor;
using UnityEngine;

public class StringInspectorField : GenericInspectorField<string>
{
    public override string ShowField(string value, GUIContent label)
    {
        return EditorGUILayout.TextField(label, value);
    }
}
