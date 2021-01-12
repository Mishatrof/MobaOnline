using UnityEngine;
using UnityEditor;
using MyAsset;

namespace MySpace.Editor
{
    [CustomEditor(typeof(FloatEvent))]
    public class FloatEventEditor : GameEventEditor<float, FloatEvent>
    {
        public override float GetArgEvent(float arg, GUIContent guiContentArg)
        {
            return EditorGUILayout.FloatField(guiContentArg, arg);
        }
    }
}
