using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemRandomer : MonoBehaviour {
	
	public Item [] item;
	public Image imageIcon;

	public AudioClip randomSound;
	public AudioSource audioSource;

	public Sprite emptyItemSprite;

	private float randomDuration = 2f;
	private float randomPerItemDuration = 0.1f;
	
	private float randomTimer;
	private float randomPerItemTimer;
	
	private bool isRandomItem;

	private float emptyItemTimer;

	// Use this for initialization
	void Start () {
		isRandomItem = false;
		randomDuration = randomSound.length;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Z)){
			RandomItem();
		}

		emptyItemTimer -= Time.deltaTime;
		if (emptyItemTimer < 0 && !isRandomItem) {
			imageIcon.sprite = emptyItemSprite;		
		}


		if (isRandomItem) {
			randomTimer -= Time.deltaTime;
			int itemIndex = Random.Range( 0 , item.Length);
			if(randomTimer > 0){
				randomPerItemTimer -= Time.deltaTime;
				if(randomPerItemTimer<0){
					imageIcon.sprite = item[itemIndex].Icon;
					randomPerItemTimer = randomPerItemDuration;
				}
			}
			else{
				imageIcon.sprite = item[itemIndex].Icon;
				item[itemIndex].Use();
				emptyItemTimer = item[itemIndex].Duration;
				isRandomItem = false;
			}
		}
	}

	public void RandomItem(){
		audioSource.PlayOneShot (randomSound);

		randomTimer = randomDuration;
		randomPerItemTimer = 0;
		isRandomItem = true;
	}
}
