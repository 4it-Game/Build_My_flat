using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	public GameObject Spawn; // The object that is going to be dropped
	public float SpawnTime =3; //How fast the objects are created
	public float Speed = 3; // how fast to move the falling object 'left and right'
	[HideInInspector]public GameObject SelectedObject; //the object that the player is currently moving

	public bool Lost = false; // the cubes all this boolen if they touch the ground

	private Transform Cam;  // storing the Main Camera

	public float CurDistance; // cal distance from the camera to the ground
	public float StartDistance; // The initial distance of the camera
	public bool MoveCam = false; // turns on if 'CurDistance' is less than 'StartDistance'
	// Use this for initialization
	void Start () {

		StartCoroutine (WaitandSpawn (SpawnTime));
		Cam = Camera.main.transform;
		StartDistance = Vector3.Distance(transform.position,GameObject.FindGameObjectWithTag("Ground").transform.position);
		CurDistance = StartDistance + 3; // adding an offset to the distance so that the camera does not move for every cube that falls
	}
	
	// Update is called once per frame
	void Update () {

		/*all the movement that happens in the game and the conditions
		 * have to be matched. All movement uses the
		 * same transform.Translate function*/

		if (Lost == false) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				SelectedObject.transform.Translate (Vector3.right * Speed * Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				SelectedObject.transform.Translate (Vector3.left * Speed * Time.deltaTime);
			}
			if(SelectedObject !=null){
			CurDistance = Vector3.Distance(transform.position,SelectedObject.transform.position) + 3;
			}

			if (CurDistance < StartDistance && MoveCam ==true) {
				Cam.Translate(Vector3.up*Time.deltaTime);
			}
			else{
				MoveCam = false;
			}

		}
	}


	IEnumerator WaitandSpawn(float WaitTime){
		// a basic wait second timer
			yield return new WaitForSeconds (WaitTime);

		//random aria where the cube can be created
			float PosX = Mathf.Round (Random.Range (-gameObject.transform.localScale.x / 2, gameObject.transform.localScale.x / 2));

			Vector3 SpawnPos = new Vector3 (PosX, gameObject.transform.position.y, gameObject.transform.position.z);
		//instantiate the cube with the new position
			GameObject Cube = Instantiate (Spawn, SpawnPos, transform.rotation) as GameObject;
			Cube.GetComponent<Rigidbody> ().drag = 4; //show down the falling of the cube
			Cube.transform.localScale = new Vector3 (Random.Range (1, 3), Random.Range (1, 3), 1);

		//let the cube add points and set the correct tag group to do so
		Cube.AddComponent<AddPoints> ();
		Cube.tag = "Active";


		// Camera//
		//turns on the movement if the camera is too low
		if (CurDistance < StartDistance) {
			MoveCam = true;
		}
		//if a new object is created and the old one has not touched a cube yet, then the game is lost
		if (SelectedObject != null && SelectedObject.tag == "Active") {
			Lost = true;
		}
			SelectedObject = Cube;
		//if the game is not lost start timer again and create more cubes.
		if(Lost == false)
			StartCoroutine (WaitandSpawn (SpawnTime));
		
	}
}
