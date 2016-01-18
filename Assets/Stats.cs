using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{

	public int Points = 0;
	public GameObject Panel;
	public Genarator _Gen;
	public Text PointsText;

	void Update ()
	{
		Panel.SetActive (_Gen.lost);
		if (Panel.activeSelf) {
			PointsText.text = "Your Score:" + Points.ToString ();
		}
	}

	public void PlayAgain ()
	{
		Application.LoadLevel ("game");
	}
}
