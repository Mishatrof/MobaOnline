using UnityEngine;
using UnityEditor;
using MyAsset;

namespace MySpace.Editor
{
    [CustomEditor(typeof(Vector2Event))]
    public class Vector2EventEditor : GameEventEditor<Vector2, Vector2Event>
    {
        public override Vector2 GetArgEvent(Vector2 arg, GUIContent guiContentArg)
        {
            return EditorGUILayout.Vector2Field(guiContentArg, arg);
        }
    }
}
