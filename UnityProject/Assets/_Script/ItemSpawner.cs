using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour {
	
	public float timeToSpawn = 5f;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = timeToSpawn;
	}
	
	// Update is called once per frame
	void Update () {
		
		timer -= Time.deltaTime;
		
		if (timer <= 0) {

			var ItemSpawnPoints = GameObject.FindGameObjectsWithTag("ItemSpawnPoint"); 
			int indexSpawPointRandom = Random.Range( 0 , ItemSpawnPoints.Length );
			var itemSpawnPoint = ItemSpawnPoints[indexSpawPointRandom].GetComponent<ItemSpawnPoint>();

			itemSpawnPoint.SpawnBox();

			timer = timeToSpawn;
		}
	}


}
