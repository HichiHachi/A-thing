using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public GameObject ship;
	float maneuverability = 1.8f;
	Vector3 position;
	Vector2 diff;
	float distance;
	float SlowDownSpeed = 0.001f;
	float ForwardSpeed = 0.005f;
	float velocity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ShipRotation ();
		MoveShip ();
		//Screen.showCursor = false;
	}

	void ShipRotation(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (Vector3.forward, (mousePos - ship.transform.position * 2.0f));
		ship.transform.rotation = Quaternion.Lerp (ship.transform.rotation, rot, Time.deltaTime*maneuverability);
	}

	void MoveShip(){
		if (Input.GetMouseButton (1)) {
			velocity +=ForwardSpeed;
			Debug.Log("RightClick");
		}
		if (Input.GetMouseButton (0)) {
			if (velocity > 0)velocity -= SlowDownSpeed;
		}
		ship.rigidbody2D.transform.position += ship.rigidbody2D.transform.up*velocity;
		if(velocity>0)velocity -= 0.0001f;
	}
}
