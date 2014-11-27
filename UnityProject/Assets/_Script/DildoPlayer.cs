using UnityEngine;
using System.Collections;

public class DildoPlayer : MonoBehaviour {

	public GameObject[] Dildos;

	private float dildoTimer;
	private bool hasDildo;
	// Use this for initialization
	void Start () {
		hasDildo = false;
	}
	
	// Update is called once per frame
	void Update () {

		dildoTimer -= Time.deltaTime;
		if (dildoTimer < 0) {
			hasDildo = false;		
		}

		foreach (var dildo in Dildos) {
			dildo.renderer.enabled = hasDildo;		
		}
	}


	public void useDildo(float duration)
	{
		hasDildo = true;
		dildoTimer = duration;
	}

	public bool isUsingDildo(){
		return hasDildo;
	}
}
