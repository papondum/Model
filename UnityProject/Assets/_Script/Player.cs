using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

	public float Health = 10000f;
	public Slider HPSlider;
	public Image AvartarImage;
	public Sprite[] AvartarSprites;

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

		float hpValueRatio = currentHealth / Health;
		HPSlider.value = hpValueRatio;

		int avartarIndex = (int)( hpValueRatio * AvartarSprites.Length  );
		avartarIndex = Mathf.Clamp (avartarIndex, 0, AvartarSprites.Length - 1);
		AvartarImage.sprite = AvartarSprites [avartarIndex];

	}

	public void Hurt(float damage)
	{
		currentHealth -= damage;
	}
}
