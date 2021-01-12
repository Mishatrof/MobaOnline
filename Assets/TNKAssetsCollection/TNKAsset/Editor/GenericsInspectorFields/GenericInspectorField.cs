using UnityEngine;


public abstract class GenericInspectorField<T>
{
    public abstract T ShowField(T value, GUIContent label);
}
