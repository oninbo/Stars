using UnityEngine;
using System.Collections;

public class CloudBehaviourScript : MonoBehaviour {

	float alpha;
	float beta;
	int r = 200;

	Vector3 PolarToXYZ(float alpha, float beta){
		float x = r * Mathf.Sin (alpha) * Mathf.Cos (beta);
		float z = r * Mathf.Sin (alpha) * Mathf.Sin (beta);
		float y = r * Mathf.Cos (alpha);
		return new Vector3 (x, y, z);
	}
	// Use this for initialization
	void Start () {
		alpha = Random.Range (30, 75) * Mathf.PI / 180f; //polar angle
		beta = Random.Range (-180, 180) * Mathf.PI / 180f; //azimuthal angle
		this.transform.position = PolarToXYZ (alpha, beta);
		this.transform.localScale = new Vector3 (0.035f, 0.035f, 0);
		this.transform.rotation = Quaternion.LookRotation (PolarToXYZ (alpha, beta));//rotate face
	}
	
	// Update is called once per frame
	void Update () {
		beta += Time.deltaTime*0.05f;
		this.transform.position = PolarToXYZ (alpha, beta);
		this.transform.rotation = Quaternion.LookRotation (PolarToXYZ (alpha, beta));//rotate face
	}
}
