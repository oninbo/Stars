using UnityEngine;
using System.Collections;

public class CloudsScript : MonoBehaviour {

	ArrayList clouds = new ArrayList();

	// Use this for initialization
	void Start () {
		for (int n=1; n<=3; n++) {
			int r = 150;
			GameObject cloud = GameObject.Instantiate (Resources.Load ("Cloud " + n)) as GameObject;
			float alpha = Random.Range (30, 70) * Mathf.PI / 180f; //polar angle
			float beta = Random.Range (-180, 180) * Mathf.PI / 180f; //azimuthal angle
			float x = r * Mathf.Sin (alpha) * Mathf.Cos (beta);
			float z = r * Mathf.Sin (alpha) * Mathf.Sin (beta);
			float y = r * Mathf.Cos (alpha);
			cloud.transform.position = new Vector3(x, y, z);
			cloud.transform.localScale = new Vector3(20, 20, 0);
			cloud.transform.rotation = Quaternion.LookRotation ((new Vector3(x, y, z)));//rotate face
			clouds.Add (cloud);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
