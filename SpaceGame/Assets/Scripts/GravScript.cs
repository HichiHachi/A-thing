using UnityEngine;
using System.Collections;

public class GravScript : MonoBehaviour {

	public float ObjectMass = 0.0f;
	float ConstG;
	float GravForce;

	// Use this for initialization
	void Start () {
		ConstG = 6.674f*(10^(-11));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerEnter2D(Collider2D col)
	{
		float Distance = Vector3.Distance (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position);
		GravForce = -ConstG * (ObjectMass/(Distance*Distance));
		col.gameObject.transform.position = Vector3.MoveTowards (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position, GravForce);
	}

	
	void OnTriggerStay2D(Collider2D col)
	{
		float Distance = Vector3.Distance (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position);
		GravForce = -ConstG * (ObjectMass/(Distance*Distance));
		col.gameObject.transform.position = Vector3.MoveTowards (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position, GravForce);
	}
}
