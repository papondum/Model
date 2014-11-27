using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	public Text scoreText;
	private float score;
	// Use this for initialization
	void Start () {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score += Time.deltaTime * 10;
		scoreText.text = "SCORE : " + (int)(score * 100);
	}
}
