using UnityEngine;
using System.Collections;

public class CountedBehaviourScript : MonoBehaviour {

	//bool fadeIn = false;
	//bool fadeOut = false;

	public void Show(){
		Vector3 v = Camera.main.cameraToWorldMatrix.MultiplyVector (Vector3.down*2);
		transform.position = Camera.main.transform.position + Camera.main.transform.forward*6 + v;
		transform.rotation = Camera.main.transform.rotation;
		StarMapController star_map_conrtoller = GameObject.Find("Sphere").GetComponent<StarMapController>();
		if (star_map_conrtoller.score == 1) {
			this.GetComponent<TextMesh> ().text = "You've counted " + star_map_conrtoller.score + " star!";
		} else {
			this.GetComponent<TextMesh> ().text = "You've counted " + star_map_conrtoller.score + " stars!";
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (transform.position.y < 10) {
			float a = this.GetComponent<TextMesh> ().color.a;
			this.GetComponent<TextMesh> ().color = new Color(1,1,1, a-Time.deltaTime*0.45f);
			transform.Translate (Vector3.up * 2 * Time.deltaTime);
		//} else {
			//this.GetComponent<TextMesh> ().color = new Color(1,1,1,0);
		//}
	}
}
