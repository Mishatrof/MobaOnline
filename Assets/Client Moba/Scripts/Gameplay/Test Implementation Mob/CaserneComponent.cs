using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaserneComponent : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform targetPoint;
    public List<GameObject> spawnMobs = new List<GameObject>(7);
    public TeamData team;

    public int lineIndex = 0;
}
