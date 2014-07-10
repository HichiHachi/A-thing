using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {
	public GameObject player;
	bool on = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1);
		this.camera.orthographicSize = 100;
		if(Input.GetKeyDown("m"))
		{
			on = !on;

		}
		if (on == true) {
						this.camera.enabled = true;

				} else {
			this.camera.enabled = false;
		
		}

		
	}
}
