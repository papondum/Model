using UnityEngine;
using System.Collections;

public class SpawnItem : MonoBehaviour {

	GameObject [] itemTospawns;
	
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

			int itemToSpawnIndex = Random.Range( 0 , itemTospawns.Length );
			itemSpawnPoint.SpawnItem( itemTospawns[itemToSpawnIndex]);
		}
	}
}
