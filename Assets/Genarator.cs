using UnityEngine;
using System.Collections;

public class Genarator : MonoBehaviour
{

	public GameObject Spawn;
	public float SpawnTime = 3;
	[HideInInspector]public GameObject SelectedObject;
	public float Speed = 3;

	public bool lost = false;

	private Transform Cam;

	public float CurDistance;

	public float StartDistance;

	public bool MoveCam = false;

	void Start ()
	{
		StartCoroutine (WaitandSpawn (SpawnTime));
		Cam = Camera.main.transform;
		StartDistance = Vector3.Distance (transform.position, GameObject.FindGameObjectWithTag ("Ground").transform.position);
		CurDistance = StartDistance + 3;
	}


	void Update ()
	{
		if (lost == false) {
			if (Input.GetKey (KeyCode.RightArrow)) {
				SelectedObject.transform.Translate (Vector3.right * Speed * Time.deltaTime);
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				SelectedObject.transform.Translate (Vector3.left * Speed * Time.deltaTime);
			}
			if (SelectedObject != null) {
				CurDistance = Vector3.Distance (transform.position, SelectedObject.transform.position);
			}
			if (CurDistance < StartDistance && MoveCam == true) {
				Cam.Translate (Vector3.up * Time.deltaTime);
			} else {
				MoveCam = false;
			}
		}
	}

	IEnumerator WaitandSpawn (float WaitTime)
	{
		yield return new WaitForSeconds (WaitTime);

		float posX = Mathf.Round (Random.Range (-gameObject.transform.localScale.x / 2, gameObject.transform.localScale.x / 2));
		Vector3 SpawnPos = new Vector3 (posX, gameObject.transform.position.y, gameObject.transform.position.z);
		GameObject Cube = Instantiate (Spawn, SpawnPos, transform.rotation) as GameObject;
		Cube.GetComponent<Rigidbody> ().drag = 4;
		Cube.transform.localScale = new Vector3 (Random.Range (1, 3), Random.Range (1, 3), 1);
		Cube.AddComponent<AddPoints> ();
		Cube.tag = "Active";
		if (CurDistance < StartDistance) {
			MoveCam = true;
		}
		if (SelectedObject != null && SelectedObject.tag == "Active") {
			lost = true;
		} 
		SelectedObject = Cube;	
		if (lost == false)
			StartCoroutine (WaitandSpawn (SpawnTime));
	}
}
