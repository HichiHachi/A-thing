using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public GameObject ship;
	public GameObject stars;
	float maneuverability = 1.8f;
	Vector3 position;
	Vector2 diff;
	float distance;
	float SlowDownSpeed = 5.002f;
	float ForwardSpeed = 5.005f;
	float velocity;
	float MaxSpeed = 0.5f;
	float lPan = 800;
	public Vector3 mousePos;
	bool Alive = true;
	bool move = false;
	
	private Vector2 G;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Alive) {
			PredictPath();
			ShipRotation ();
			MoveShip ();
			SetStarLifeSpan ();
			if(move==true){
				ship.rigidbody2D.AddForce(ship.transform.up*velocity);
				//move=false;
			}
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
				Debug.Log (velocity);
				move = true;
				ship.transform.GetComponent<TrailRenderer>().enabled = true;
			}
		}
		if (Input.GetMouseButton (0)) {
			if (velocity > 0)velocity -= SlowDownSpeed;
			if (velocity <=0.01)ship.transform.GetComponent<TrailRenderer>().enabled = false;
		}
		//ship.rigidbody2D.transform.position += ship.rigidbody2D.transform.up*velocity;
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

	void PredictPath()
	{

		int vertices = 60;
		Vector2 momentum = ship.transform.rigidbody2D.velocity;
		Vector2 pos = ship.transform.position;
		Vector2 last = ship.transform.position;
		

		ship.transform.GetComponent<LineRenderer> ().SetVertexCount (vertices);
		//ship.transform.GetComponent<LineRenderer> ().SetPosition (0, ship.transform.position);
		for (int i = 0; i<vertices; i++) {
			
			ship.transform.GetComponent<LineRenderer> ().SetPosition (0, ship.transform.position);
			float temp = GameObject.Find("Gravity").GetComponent<GravScript> ().GetGForce (pos);
			G = new Vector2(temp,temp);
			momentum+=G;
			pos=momentum*i;
			ship.transform.GetComponent<LineRenderer>().SetPosition(i,pos);
			last = pos;
		}



	}
}
