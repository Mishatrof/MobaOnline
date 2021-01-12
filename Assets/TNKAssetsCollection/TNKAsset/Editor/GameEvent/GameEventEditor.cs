using UnityEngine;
using UnityEditor;
using MyAsset;

namespace MySpace.Editor
{
    public class GameEventEditor<T, GE> : UnityEditor.Editor
      //  where GIF : GenericInspectorField<T>
        where GE : GameEvent<T> 
    {
        private T EventArg = default(T);
       // private GIF InspectorField = default;


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            if (Application.isPlaying)
            {
                GE gameEvent = target as GE;


                EditorGUILayout.LabelField("Count Listeners: " + gameEvent.countListeners);


                GUIContent guiContentArg = new GUIContent("Arg");
                EventArg = GetArgEvent(EventArg, guiContentArg);

                if (GUILayout.Button("Raise"))
                {
                    gameEvent.Raise(EventArg);
                }
            }
            else
            {
                EditorGUILayout.HelpBox("События можно вызывать только в режиме игры", MessageType.Warning);
            }
        }


        public virtual T GetArgEvent(T arg, GUIContent guiContentArg)
        {
            return arg;
        }
    }
}