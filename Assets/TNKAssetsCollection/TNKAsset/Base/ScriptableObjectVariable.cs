using UnityEngine;

namespace MyAsset
{
    public abstract class ScriptableObjectVariable<T, GE> : ScriptableObject
        where GE : GameEvent<T>
    {
        // Раньше это было #if UNITY_EDITOR, но была проблема с разметкой памяти на настольных платформах
        [TextArea]
        public string DeveloperDescription;

        [SerializeField]
        private T m_Value = default;
        [SerializeField]
        private VoidEvent m_ChangedVoid;


        public T value
        {
            get { return m_Value; }
            set { SetValue(value); }
        }


        public void SetValue(ScriptableObjectVariable<T, GE> variable)
        {
            SetValue(variable.value);
        }

        public void SetValue(T value)
        {
            if (m_Value.Equals(value))
                return;

            m_Value = value;

            m_ChangedVoid?.Raise();
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
