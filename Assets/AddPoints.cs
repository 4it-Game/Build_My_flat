using UnityEngine;
using System.Collections;

public class AddPoints : MonoBehaviour
{
	public int PointsToAdd = 5;
	private Stats _stats;

	void Start ()
	{
		_stats = Camera.main.GetComponent<Stats> ();
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Grounded" && gameObject.tag == "Active") {
			gameObject.tag = "Grounded";
			_stats.Points = _stats.Points = PointsToAdd;

		}
		if (collision.gameObject.tag == "Ground") {
			GameObject _Gen = GameObject.FindGameObjectWithTag ("Generator");
			_Gen.GetComponent<Genarator> ().lost = true;
		}
	}
}
