using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public GameObject ship;
	public GameObject stars;
	float maneuverability = 1.8f;
	Vector3 position;
	Vector2 diff;
	float distance;
	float SlowDownSpeed = 0.002f;
	float ForwardSpeed = 0.005f;
	float velocity;
	float MaxSpeed = 0.5f;
	float lPan = 800;
	public Vector3 mousePos;
	bool Alive = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Alive) {
			ShipRotation ();
			MoveShip ();
			SetStarLifeSpan ();
			} else {
			ship.transform.GetComponent<SpriteRenderer>().enabled = false;
			ship.transform.GetComponent<TrailRenderer>().enabled = false;
		}
		//Screen.showCursor = false;
	}

	void ShipRotation(){
		mousePos = Input.mousePosition;
		mousePos.x -= Screen.width/2;
		mousePos.y -= Screen.height/2;
		Quaternion rot = Quaternion.LookRotation (Vector3.forward, (mousePos));// - ship.transform.position * 2.0f)); -- removed fixed mouse pos
		ship.transform.rotation = Quaternion.Lerp (ship.transform.rotation, rot, Time.deltaTime*maneuverability);
	}

	void MoveShip(){
		if (Input.GetMouseButton (1)) {
			if (velocity <= MaxSpeed) {
				velocity += ForwardSpeed;
				ship.transform.GetComponent<TrailRenderer>().enabled = true;
			}
		}
		if (Input.GetMouseButton (0)) {
			if (velocity > 0)velocity -= SlowDownSpeed;
			if (velocity <=0.01)ship.transform.GetComponent<TrailRenderer>().enabled = false;
		}
		ship.rigidbody2D.transform.position += ship.rigidbody2D.transform.up*velocity;
		if(velocity>0)velocity -= 0.0001f;
	}

	void SetStarLifeSpan(){

		if (velocity < MaxSpeed / 3) {
						lPan = 800;
				}
		if (velocity >= MaxSpeed / 3 && velocity < (MaxSpeed / 3) * 2) {
						lPan = 500;
				}
		if (velocity > (MaxSpeed / 3) * 2) {
						lPan = 10;
				}
		//stars.GetComponent<particle> ().SetLifespan (lPan);
	
	}

	public void Die()
	{
		Alive = false;
		ship.transform.GetComponent<ParticleSystem> ().Play ();
		Destroy (gameObject, 5);

	}
}
