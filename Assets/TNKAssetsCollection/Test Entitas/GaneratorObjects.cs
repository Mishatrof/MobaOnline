using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAsset.TestEntitas
{
    public class GaneratorObjects : MonoBehaviour
    {
        public GameController gameController;
        public GameObject instance;
        public int countX;
        public int countY;

        public void Start()
        {
            for (int x = 0; x < countX; x++)
                for (int y = 0; y < countY; y++)
                {
                    if (Random.value > 0.5f)
                        gameController.context.Instantiate(instance, new Vector3(x, 0f, y), Quaternion.identity);
                    else
                        gameController.context.Instantiate(instance, new Vector3(x, 0f, y), Quaternion.identity).AddComponent<MoveComponent>();
                }
        }
    }
}
