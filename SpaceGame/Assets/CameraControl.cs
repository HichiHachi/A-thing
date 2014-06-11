using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject player;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1);
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			if(Camera.main.orthographicSize>5)Camera.main.orthographicSize--;
			Debug.Log("Forward");
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if(Camera.main.orthographicSize<25)Camera.main.orthographicSize++;
			Debug.Log("Back");
		}
	}
}
