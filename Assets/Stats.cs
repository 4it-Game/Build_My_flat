using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{

	public int Points = 0;
	public GameObject Panel;
	public Genarator _Gen;

	void Update ()
	{
		Panel.SetActive (_Gen.lost);
	}

	public void PlayAgain ()
	{
		Application.LoadLevel ("game");
	}
}
