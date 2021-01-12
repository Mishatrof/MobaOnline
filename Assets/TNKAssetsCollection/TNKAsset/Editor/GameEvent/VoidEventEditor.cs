using UnityEngine;
using UnityEditor;

namespace MyAsset
{
    [CustomEditor(typeof(VoidEvent))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying)
            {
                VoidEvent voidEvent = target as VoidEvent;


                EditorGUILayout.LabelField("Count Listeners: " + voidEvent.countListeners);


                if (GUILayout.Button("Raise"))
                    voidEvent.Raise();
            }
            else
            {
                EditorGUILayout.HelpBox("События можно вызывать только в режиме игры", MessageType.Warning);
            }
        }
    }
}
