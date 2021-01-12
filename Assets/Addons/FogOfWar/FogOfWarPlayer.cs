using UnityEngine;
using System.Collections;

public class FogOfWarPlayer : MonoBehaviour {
	
	public Transform FogOfWarPlane;
	public int Number = 1;
    public LayerMask layerMask;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
		Ray rayToPlayerPos = Camera.main.ScreenPointToRay(screenPos);

        

		if(Physics.Raycast(rayToPlayerPos, out var hit, 1000, layerMask)) {

            Debug.DrawRay(hit.point, hit.normal);
            FogOfWarPlane.GetComponent<Renderer>().material.SetVector("_Player" + Number.ToString() +"_Pos", hit.point);
		}
	}
}
