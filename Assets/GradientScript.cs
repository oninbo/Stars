using UnityEngine;
using System.Collections;

public class GradientScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Vector2[] uv = mesh.uv;
		Color[] colors = new Color[uv.Length];
		for (int i=0; i < uv.Length; i++) {
			colors [i] = Color.Lerp (Color.red, Color.green, uv [i].x); 
		}

		mesh.colors = colors;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
