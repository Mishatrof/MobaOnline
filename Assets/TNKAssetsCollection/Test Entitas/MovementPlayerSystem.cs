using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAsset.TestEntitas
{
    public class MovementPlayerSystem : MonoSystem
    {
        public override void Execute(Context context)
        {
            Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            if (velocity == Vector3.zero)
                return;

            velocity *= Time.deltaTime;

            foreach (var player in context.GetComponents<PlayerComponent>())
            {
                if (player.GetComponent<MoveComponent>())
                    player.transform.position += velocity;
            }
        }
    }
}
