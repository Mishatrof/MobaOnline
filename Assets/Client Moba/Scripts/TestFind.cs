using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyAsset.Extensions;
using UnityEngine.EventSystems;

public class TestFind : MonoBehaviour
{
    //public List<GameObject> m_List;
    //public List<GameObject> m_Find;

    public int generateCount;

    [ContextMenu("Generate")]
    void Generate()
    {
        for (int x = 0; x < generateCount/2; x++)
        {
            for (int y = 0; y < generateCount / 2; y++)
            {
                GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

                if (Random.value > 0.5f)
                    newObject.AddComponent<TestBechaviour>();
                //if (Random.value > 0.5f)
                //    newObject.AddComponent<ControllManager>();
                //if (Random.value > 0.5f)
                //    newObject.AddComponent<TestFind>();

                newObject.transform.SetParent(transform);
                newObject.transform.position = new Vector3(x, 0f, y);
                newObject.transform.localScale = Vector3.one * 0.8f;

                //m_List.Add(newObject);
            }
        }
    }

    //[ContextMenu("Find")]
    //void Find()
    //{
    //    bool Filter(GameObject obj)
    //    {
    //        return obj.GetComponent<Team>() && obj.GetComponent<ControllManager>();
    //    }

    //    //m_Find = m_List.FindAll((obj) => Filter(obj));
    //}

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            gameObject.BroadcastMessage("OnMove", new Vector3(Random.value-Random.value, 0f, Random.value-Random.value));
    }
}
