using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyAsset.Extensions;
using NaughtyAttributes;

namespace MyAsset.TestEntitas
{
    public class GameController : MonoBehaviour
    {
        [SerializeField, ReorderableList]
        private List<MonoSystem> m_Systems;

        public Context context { get; private set; }

        [ContextMenu("Find")]
        // Start is called before the first frame update
        void Awake()
        {
            context = new Context();

            foreach (MonoBehaviour mono in FindObjectsOfType<MonoBehaviour>())
            {
                if (mono is IComponent)
                    context.AddComponent(mono as IComponent);
            }
        }

        [ContextMenu("Update")]
        void Update()
        {
            m_Systems.ForEach(s => s.Execute(context));
        }
    }
}