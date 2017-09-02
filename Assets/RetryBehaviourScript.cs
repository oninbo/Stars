using UnityEngine;
using System.Collections;

public class RetryBehaviourScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		SetGazedAt(false);
	}
	
	public void SetGazedAt(bool check) {
		Color look = new Color (0.27f, 1f, 0.30f);//new Color(68, 255, 77)
		Color unlook = new Color (0.93f, 0.27f, 1f); // new Color(237, 68, 255)
		this.GetComponent<TextMesh> ().color = check ? look : unlook;
	}
	
	public void Clicked(){
		Handheld.Vibrate ();
		StarMapController star_map_conrtoller = (StarMapController)GameObject.Find("Sphere").GetComponent(typeof(StarMapController));
		star_map_conrtoller.MakeStar(100);
		DestroyObject (GameObject.Find ("Exit Text(Clone)"));
		DestroyObject (GameObject.Find ("Score Text(Clone)"));
		Destroy (GameObject.Find ("Retry Text(Clone)"));
	}
	
	public void ToggleVRMode() {
		Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
