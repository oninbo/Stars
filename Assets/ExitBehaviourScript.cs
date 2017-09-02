using UnityEngine;
using System.Collections;

public class ExitBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetGazedAt (false);
	}
	
	public void SetGazedAt(bool check) {
		Color look = new Color (0.96f, 1f, 0.27f);
		Color unlook = new Color (0.93f, 0.27f, 1f);
		this.GetComponent<TextMesh> ().color = check ? look : unlook;
	}
	
	public void Clicked(){
		Handheld.Vibrate ();
		Application.Quit ();
	}
	
	public void ToggleVRMode() {
		Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
