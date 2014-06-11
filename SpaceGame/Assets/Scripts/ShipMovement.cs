using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public GameObject ship;
	float rotation = 0.8f;
	Vector3 position;
	Vector2 diff;
	float distance;
	float Radius = 25.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ShipRotation ();	
		MouseRadius ();
	}

	void ShipRotation(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		ship.transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position * Time.deltaTime);
	
	}

	void MouseRadius(){


	}
}
