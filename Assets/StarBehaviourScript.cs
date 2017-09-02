using UnityEngine;
using System.Collections;

public class StarBehaviourScript : MonoBehaviour {
	bool fadeIn = true;
	// Use this for initialization
	void Start () {
		SetGazedAt(false);
	}

	public void SetGazedAt(bool check) {
		this.GetComponent<SpriteRenderer>().material.color = check ? Color.magenta : Color.white;
	}

	public void Clicked(){
		Destroy (GameObject.Find ("Counted Text(Clone)"));
		Handheld.Vibrate ();
		//Debug.Log ("clicked: " + this.name);
		StarMapController star_map_conrtoller = GameObject.Find("Sphere").GetComponent<StarMapController>();
		star_map_conrtoller.counted = this.gameObject;
	}

	public void ToggleVRMode() {
		Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
	}

	// Update is called once per frame
	void Update () {
		float a = this.GetComponent<SpriteRenderer> ().color.a;
		Color star_color = this.GetComponent<SpriteRenderer> ().color;
		//Debug.Log (a);
		if (a >=1) {
			fadeIn = false;
		} else if(a <= 0.2){
			fadeIn = true;
		}

		if (fadeIn) {
			this.GetComponent<SpriteRenderer> ().color = new Color (star_color.r, star_color.b, star_color.g, a + Time.deltaTime*0.5f);
		} else {
			this.GetComponent<SpriteRenderer> ().color = new Color (star_color.r, star_color.b, star_color.g, a - Time.deltaTime*0.5f);
		}
	}
}
