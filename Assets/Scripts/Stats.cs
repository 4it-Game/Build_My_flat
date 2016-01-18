using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Stats : MonoBehaviour {
	public int Points = 0; // total points
	public GameObject Panel; //GUI panel that is turned on when we lose the game
	public Generator _Gen;  // The generator that tells us if we lost the game
	public Text PointsText; // the text to change when the panel turns on
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Panel.SetActive (_Gen.Lost);
		if (Panel.activeSelf) {
			PointsText.text = "Your Score:" + Points.ToString();
		}

	}

	public void PlayAgain(){
		Application.LoadLevel ("Game");
	}
}
