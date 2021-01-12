using UnityEngine;
using MyAsset;

public class GameObjectItem : MonoBehaviour
{
    [SerializeField]
    private GameObjectList m_List;
    

    void OnEnable()
    {
        m_List.Add(gameObject);
    }

    void OnDisable()
    {
        m_List.Remove(gameObject);
    }
}
