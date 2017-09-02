using UnityEngine;
using System.Collections;

public class StarMapController : MonoBehaviour {

	//GameObject starObject;
	ArrayList star_list = new ArrayList();
	ArrayList star_map = new ArrayList ();
	//Color[] star_colors = {Color.white, new Color(0.3f, 0.9f, 0.36f), new Color(0.99f, 0.99f, 0.3f),
	//	new Color(0.59f, 0.96f, 0.98f), new Color(0.97f, 0.8f, 0.43f)};
	public int score = 0;
	float r = 100;

	public GameObject counted;

	void SetMap(){
		for (int alpha=30; alpha<=70; alpha+=10) {
			for (int beta=-180; beta<=180; beta+=10) {
				float x = r * Mathf.Sin (alpha * Mathf.PI / 180f) * Mathf.Cos (beta * Mathf.PI / 180f);
				float z = r * Mathf.Sin (alpha * Mathf.PI / 180f) * Mathf.Sin (beta * Mathf.PI / 180f);
				float y = r * Mathf.Cos (alpha * Mathf.PI / 180f);
				star_map.Add(new Vector3(x, y ,z));
			}
		}
	}

	public void MakeStar(float r){
		System.Random random = new System.Random();
		float size = Random.Range(1,2) + (float)random.NextDouble();

		GameObject starObject = 
			GameObject.Instantiate (Resources.Load ("StarObject")) as GameObject; //creating star
		starObject.name = "StarObject " + star_list.Count;
		//starObject.GetComponent<SpriteRenderer> ().color = star_colors[Random.Range (0, star_colors.Length - 1)];
		int indexOfPlace = Random.Range (0, star_map.Count - 1);
		starObject.transform.position = (Vector3)star_map[indexOfPlace];//new Vector3 (x, y, z);
		starObject.transform.RotateAround (starObject.transform.position, starObject.GetComponent<BoxCollider>().center, Random.Range (-180, 180));
		starObject.transform.rotation = Quaternion.LookRotation ((Vector3)star_map [indexOfPlace]);//(new Vector3 (x, y, z)); //rotating face
		starObject.transform.localScale = new Vector3(size, size, size);

		star_map.RemoveAt (indexOfPlace);
		star_list.Add (starObject);
	}

	// Use this for initialization
	void Start () {
		SetMap ();
		MakeStar (r);
	}

	void GameOver(){
		AudioSource sound = GameObject.Find("Game Over Sound").GetComponent<AudioSource>();
		sound.Play ();
		foreach (GameObject star in star_list) {
			DestroyObject (star);
		}
		star_list.Clear ();
		Destroy (GameObject.Find ("Counted Text(Clone)"));
		//Vector3 v_down = Camera.main.cameraToWorldMatrix.MultiplyVector (Vector3.down);
		GameObject score_text =
			GameObject.Instantiate(Resources.Load ("Score Text"), Camera.main.transform.position + Camera.main.transform.forward*90, Camera.main.transform.rotation) as GameObject;
		GameObject retry_text =
			GameObject.Instantiate(Resources.Load ("Retry Text")) as GameObject;
		retry_text.transform.position = new Vector3 ((float)-33.9, (float)18.5, (float)28.8);
		retry_text.transform.rotation = Quaternion.LookRotation (retry_text.transform.position);
		GameObject exit_text =
			GameObject.Instantiate(Resources.Load ("Exit Text")) as GameObject;
		exit_text.transform.position = new Vector3 ((float)26, (float)18.5, (float)28.8);
		exit_text.transform.rotation = Quaternion.LookRotation (exit_text.transform.position);
		score_text.GetComponent<TextMesh> ().text = "Game over!\n Score: " + score;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (star_list.Count > 0) {
			if (counted == star_list [star_list.Count - 1]) {
				MakeStar (r);
				score ++;
				counted = null;
				GameObject counted_text = GameObject.Instantiate (Resources.Load ("Counted Text")) as GameObject;
				CountedBehaviourScript counted_script = counted_text.GetComponent<CountedBehaviourScript> ();
				counted_script.Show ();
			} else if (counted) {
				GameOver();
			}
		}
	}
}
