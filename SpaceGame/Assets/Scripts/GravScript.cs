using UnityEngine;
using System.Collections;

public class GravScript : MonoBehaviour {

	public float ObjectMass = 0.0f;
	float ConstG;
	float GravForce;
	public GUITexture HUDtexture;
	public GUIText HUDtext;
	Vector2 dir;


	// Use this for initialization
	void Start () {
		ConstG = 6.674f*(10^(-11));
		HUDtext.enabled = false;
		HUDtexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnTriggerEnter2D(Collider2D col)
	{
		float Distance = Vector3.Distance (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position);
		GravForce = -ConstG * (ObjectMass/(Distance*Distance));
		//col.gameObject.transform.position = Vector3.MoveTowards (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position, GravForce);
		dir = col.gameObject.transform.position - this.transform.parent.gameObject.transform.position;
		dir = dir.normalized;
		col.gameObject.transform.rigidbody2D.AddForce(-dir * GravForce);
		HUDtext.enabled = true;
		HUDtexture.enabled = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		HUDtext.enabled = false;
		HUDtexture.enabled = false;		
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		float Distance = Vector3.Distance (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position);
		GravForce = -ConstG * (ObjectMass/(Distance*Distance));
		//col.gameObject.transform.position = Vector3.MoveTowards (col.gameObject.transform.position, this.transform.parent.gameObject.transform.position, GravForce);
		dir = col.gameObject.transform.position - this.transform.parent.gameObject.transform.position;
		dir = dir.normalized;
		col.gameObject.transform.rigidbody2D.AddForce(-dir * GravForce*10);
		float gForce = Mathf.Round (GravForce * 100f);
		if (gForce < 15)
						HUDtext.color = Color.blue;
		if (gForce >= 15 && gForce < 20)
						HUDtext.color = Color.yellow;
		if (gForce >= 20)
						HUDtext.color = Color.red;

		HUDtext.text = ("\tGForce: " + gForce);
	}


}
