using UnityEngine;
using UnityEditor;
using MyAsset;

namespace MySpace.Editor
{
    [CustomEditor(typeof(GameObjectEvent))]
    public class GameObjectEventEditor : GameEventEditor<GameObject, GameObjectEvent>
    {
        public override GameObject GetArgEvent(GameObject arg, GUIContent guiContentArg)
        {
            return EditorGUILayout.ObjectField(guiContentArg, arg, typeof(GameObject)) as GameObject;
        }
    }
}
