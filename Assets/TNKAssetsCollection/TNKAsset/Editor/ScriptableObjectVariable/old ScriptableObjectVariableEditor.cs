using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MyAsset;


//public class ScriptableObjectVariableEditor<T, GE, GIF> : Editor
//    where GIF : GenericInspectorField<T>, new()
//    where GE : GameEvent<T>
//{
//    protected GIF InspectorField = new GIF();

//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//        hideFlags = HideFlags.HideInInspector;
//        ScriptableObjectVariable<T, GE> variable = target as ScriptableObjectVariable<T, GE>;
        
//        if (Application.isPlaying)
//            variable.value = InspectorField.ShowField(variable.value, new GUIContent("Runtime Value"));
//    }


//    public override bool RequiresConstantRepaint()
//    {
//        return true;
//    }
//}


//[CustomEditor(typeof(IntVariable))]
//public class IntVariableEditor : ScriptableObjectVariableEditor<int, IntEvent, IntInspectorField>
//{ }


//[CustomEditor(typeof(FloatVariable))]
//public class FloatVariableEditor : ScriptableObjectVariableEditor<float, FloatEvent, FloatInspectorField>
//{ }


//[CustomEditor(typeof(StringVariable))]
//public class StringtVariableEditor : ScriptableObjectVariableEditor<string, StringEvent, StringInspectorField>
//{ }
