using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public GameObject [] enemyPrefab;

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

			var enemySpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint"); 
			int spawnPointIndex = Random.Range( 0 , enemySpawnPoints.Length );
			Transform spawnPoint = enemySpawnPoints[spawnPointIndex].transform;

			int enemyPrefabIndex = Random.Range( 0 , enemyPrefab.Length );
			Instantiate( enemyPrefab[enemyPrefabIndex] , spawnPoint.position , spawnPoint.rotation);
			timer = timeToSpawn;		
		}




	}
}
