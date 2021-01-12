using UnityEngine;

namespace MyAsset
{
    //public abstract class ScriptableObjectVariable<T, GE> : ScriptableObject
    //    where GE : GameEvent<T>
    //{
    //    // Раньше это было #if UNITY_EDITOR, но была проблема с разметкой памяти на настольных платформах
    //    [Multiline]
    //    public string DeveloperDescription;

    //    [SerializeField]
    //    private T m_InitialValue = default;
    //    private T m_RuntimeValue;

    //    // Появилась идея заменить на VoidEvent
    //    // Variable, VoidEvent
    //    // OnEnable init, subscribe
    //    // OnDisable insubscribe
    //    [SerializeField]
    //    private GE m_Changed = null;
    //    [SerializeField]
    //    private VoidEvent m_ChangedVoid;


    //    public T initialValue
    //    {
    //        get { return m_InitialValue; }
    //    }


    //    public T value
    //    {
    //        get { return m_RuntimeValue; }
    //        set { SetValue(value); }
    //    }

        

    //    private void SetValue(T value)
    //    {
    //        if (m_RuntimeValue.Equals(value))
    //            return;
            
    //        m_RuntimeValue = value;

    //        if (m_Changed)
    //            m_Changed.Raise(value);
    //        if (m_ChangedVoid)
    //            m_ChangedVoid.Raise();
    //    }


    //    public override string ToString()
    //    {
    //        return value.ToString();
    //    }


    //    private void OnEnable()
    //    {
    //        m_RuntimeValue = m_InitialValue;
    //    }
    //}
}
