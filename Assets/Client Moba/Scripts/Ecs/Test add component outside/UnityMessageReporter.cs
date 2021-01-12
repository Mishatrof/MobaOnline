using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class UnityMessageReporter : MonoBehaviour
    {
        public EcsStartup startup;
        public KeyCode key;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(key))
            {
                startup._world.CreateEntityWith(out MessageComponent message);
                message.value = $"Key down {key}";
            }
        }
    }
}
