using UnityEngine;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour
{

    public int line;
    public SpawnerCrips[] lines;
    public Image[] icons;
    public GameObject[] prefabsXuesos;
    public Text t;
    public int ZamenaCount = 0;

    public void SetLine(int _line)
    {
          line = _line;
    }

    private void Update()
    {
        if (ZamenaCount >= 7)
            ZamenaCount = 0;
        for (int i = 0; i < 7; i++)
        {
            icons[i].color = lines[line].crips[i].GetComponent<MeshRenderer>().sharedMaterial.color;
        }
        t.text = lines[line].firetimer.ToString("0");
    }

    public void clickButton(GameObject prefab)
    {
        lines[line].crips[ZamenaCount] = prefab;

        ZamenaCount += 1;   
    }
}
    