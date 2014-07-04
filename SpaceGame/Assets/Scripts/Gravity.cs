using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	float Distance;
	public float Strength = 1.0f;
	private float CurrGravStrength = 1.0f;
	public float GravSize = 1.0f;
	public float ObjectSize = 1.0f;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	}



	void OnTriggerEnter2D(Collider2D col)
	{
		Distance = Vector3.Distance (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position) - (ObjectSize/2.0f);

		CurrGravStrength = Strength*(1.0f/(Distance/(GravSize - ObjectSize)));
		col.gameObject.transform.position = Vector3.MoveTowards (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position, CurrGravStrength);

	}
	void OnTriggerStay2D(Collider2D col)
	{
		Distance = Vector3.Distance (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position) - (ObjectSize/2.0f);
		CurrGravStrength = Strength*(1.0f/(Distance/(GravSize - ObjectSize)));
		col.gameObject.transform.position = Vector3.MoveTowards (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position, CurrGravStrength);
		Debug.Log ("Gravitational Pull " + Strength * (1 / Distance));
	}
}
