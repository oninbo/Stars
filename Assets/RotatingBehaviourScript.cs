using UnityEngine;
using System.Collections;

public class RotatingBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Camera.main.transform);
		this.transform.position = new Vector3(Camera.main.transform.forward.x+2, Camera.main.transform.forward.y+2, Camera.main.transform.forward.z);
		//this.transform.rotation = Quaternion.LookRotation (this.transform.position);
	}
}
