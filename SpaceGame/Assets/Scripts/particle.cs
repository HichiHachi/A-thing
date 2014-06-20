using UnityEngine;
using System.Collections;

public class particle : MonoBehaviour {
	public GameObject ship;
	float Lifespan = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.particleSystem.startLifetime = Lifespan;
		Debug.Log ("particle " +Lifespan);
	}

	public void SetLifespan(float t){
		Lifespan = t;
	
	}

}
