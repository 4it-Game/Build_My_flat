using UnityEngine;
using System.Collections;

public class AddPoints : MonoBehaviour {
	public int PointsToAdd = 5; // the amount of points that will be added to our desplay in stats
	private Stats _stats; //storing  the stats script

	void Start(){
		/* Becaue the stats script is attached to the camera
		 * we grab the script using the Camera.main function*/
		_stats = Camera.main.GetComponent<Stats> (); 
	}

	void OnCollisionEnter(Collision collision){
		/*this part of the script sees if the current object touched an already grounded object*/
		if(collision.gameObject.tag == "Grounded" && gameObject.tag == "Active"){
			gameObject.tag = "Grounded";
			_stats.Points = _stats.Points + PointsToAdd;
		}
		/*Checks if we touched the ground. If so, end the game*/
		if (collision.gameObject.tag == "Ground") {
			GameObject _Gen = GameObject.FindGameObjectWithTag("Generator");
			_Gen.GetComponent<Generator>().Lost = true;
		}
	}
}
