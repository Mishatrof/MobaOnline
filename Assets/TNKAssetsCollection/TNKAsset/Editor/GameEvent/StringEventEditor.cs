using UnityEngine;
using UnityEditor;
using MyAsset;

namespace MySpace.Editor
{
    [CustomEditor(typeof(StringEvent))]
    public class StringEventEditor : GameEventEditor<string, StringEvent>
    {
        public override string GetArgEvent(string arg, GUIContent guiContentArg)
        {
            return EditorGUILayout.TextField(guiContentArg, arg);
        }
    }
}
