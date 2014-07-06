using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

	private float Size;
	private float RotationSpeed;
	private float RotationDir;
	private float GravitationalPull;
	private float GravitationRadius;

	// Use this for initialization
	void Start () {
		//get Random values for all values
		Size = Random.Range (50.0f, 200.0f);
		RotationDir = Random.Range (0.0f, 360f);
		RotationSpeed = Random.Range (0.2f, 1.5f);
		GravitationalPull = Random.Range (0f, 5f);
		GravitationRadius = Random.Range (0.42f, 0.5f);
		//Create the planet
		transform.localScale = new Vector3(Size,Size,0);
		transform.localRotation = Quaternion.Euler (new Vector3(0,0,RotationDir));
		transform.GetComponent<Animator> ().speed = RotationSpeed;
		GameObject.Find ("Gravity").transform.GetComponent<CircleCollider2D> ().radius = GravitationRadius*(Size/100);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Update");
	}

	private void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.GetComponent<ShipMovement>().Die();
				}
	}

}
	
