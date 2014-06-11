using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public GameObject ship;
	public GameObject ship2;
	float maneuverability = 0.8f;
	Vector3 position;
	Vector2 diff;
	float distance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ShipRotation ();	
		Screen.showCursor = false;
	}

	void ShipRotation(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (Vector3.forward, (mousePos - ship.transform.position * 2.0f));
		ship.transform.rotation = Quaternion.Lerp (ship.transform.rotation, rot, Time.deltaTime*maneuverability);
	}
}
