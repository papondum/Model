using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public float Health = 10000f;
	public Slider HPSlider;
	private float currentHealth;
	// Use this for initialization
	void Start () {
		currentHealth = Health;
	}
	
	// Update is called once per frame
	void Update () {
		//TODO gameover;
		if (currentHealth < 0) {
			Debug.Log("Game Over");		
		}
		HPSlider.value = currentHealth / Health;
	}

	public void Hurt(float damage)
	{
		currentHealth -= damage;
	}
}
