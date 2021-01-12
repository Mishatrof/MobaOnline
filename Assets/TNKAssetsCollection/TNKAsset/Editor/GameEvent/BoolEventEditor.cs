using UnityEngine;
using UnityEditor;
using MyAsset;

namespace MySpace.Editor
{
    [CustomEditor(typeof(BoolEvent))]
    public class BoolEventEditor : GameEventEditor<bool, BoolEvent>
    {
        public override bool GetArgEvent(bool arg, GUIContent guiContentArg)
        {
            return EditorGUILayout.Toggle(guiContentArg, arg);
        }
    }
}
