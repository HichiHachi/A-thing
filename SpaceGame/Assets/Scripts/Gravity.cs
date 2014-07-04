using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	float Distance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}



	void OnTriggerEnter2D(Collider2D col)
	{
		Distance = Vector3.Distance (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position);
		col.gameObject.transform.position = Vector3.MoveTowards (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position, 5.9f*(1/Distance));
	}
	void OnTriggerStay2D(Collider2D col)
	{
		Distance = Vector3.Distance (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position);
		col.gameObject.transform.position = Vector3.MoveTowards (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position, 5.9f*(1/Distance));
		Debug.Log ("Gravitational Pull " + 5.9 * (1 / Distance));
	}
}
