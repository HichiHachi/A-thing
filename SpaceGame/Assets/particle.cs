using UnityEngine;
using System.Collections;

public class particle : MonoBehaviour {
	public GameObject ship;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = ship.transform.position;
	}
}
