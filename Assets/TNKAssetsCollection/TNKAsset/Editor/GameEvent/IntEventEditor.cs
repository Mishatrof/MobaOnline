using UnityEngine;
using UnityEditor;
using MyAsset;

namespace MySpace.Editor
{
    [CustomEditor(typeof(IntEvent))]
    public class IntEventEditor : GameEventEditor<int, IntEvent>
    {
        public override int GetArgEvent(int arg, GUIContent guiContentArg)
        {
            return EditorGUILayout.IntField(guiContentArg, arg);
        }
    }
}
